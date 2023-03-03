using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Collections;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using yijianyouxie.Log;

namespace Games.TLBB.Util
{
    public class GameUtil
    {
        public static void PlatformGC()
        {
#if UNITY_WEBGL && TLBB_WXMINI && !UNITY_EDITOR
            WeChatWASM.WX.TriggerGC();
#else
            System.GC.GetTotalMemory(true);
#endif
        }

        //static Material[] mats1 = new Material[1];
        //static Material[] mats2 = new Material[2];
        //public static void SetSharedMaterial2(Renderer r, Material mat1, Material mat2)
        //{
        //    mats2[0] = mat1;
        //    mats2[1] = mat2;
        //    r.sharedMaterials = mats2;
        //    mats2[0] = null;
        //    mats2[1] = null;
        //}

        //public static void SetMaterial2(Renderer r, Material mat1, Material mat2)
        //{
        //    mats2[0] = mat1;
        //    mats2[1] = mat2;
        //    r.materials = mats2;
        //    mats2[0] = null;
        //    mats2[1] = null;
        //}

        //public static void SetSharedMaterial1(Renderer r, Material mat1)
        //{
        //    mats1[0] = mat1;
        //    r.sharedMaterials = mats1;
        //    mats1[0] = null;
        //}

        //public static void SetMaterial1(Renderer r, Material mat1)
        //{
        //    mats1[0] = mat1;
        //    r.materials = mats1;
        //    mats1[0] = null;
        //}

        static class EncodingUtility
        {
            internal static readonly KeyValuePair<byte[], Encoding>[] encodingLookup;

            internal static readonly Encoding targetEncoding =
                Encoding.GetEncoding(Encoding.UTF8.CodePage,
                    new EncoderReplacementFallback("�"),
                    new DecoderReplacementFallback("�"));

            static EncodingUtility()
            {
                Encoding utf32BE = new UTF32Encoding(true, true, true);
                Encoding utf32LE = new UTF32Encoding(false, true, true);
                Encoding utf16BE = new UnicodeEncoding(true, true, true);
                Encoding utf16LE = new UnicodeEncoding(false, true, true);
                Encoding utf8BOM = new UTF8Encoding(true, true);

                encodingLookup = new KeyValuePair<byte[], Encoding>[]
                {
                    new KeyValuePair<byte[], Encoding>(utf32BE.GetPreamble(), utf32BE),
                    new KeyValuePair<byte[], Encoding>(utf32LE.GetPreamble(), utf32LE),
                    new KeyValuePair<byte[], Encoding>(utf16BE.GetPreamble(), utf16BE),
                    new KeyValuePair<byte[], Encoding>(utf16LE.GetPreamble(), utf16LE),
                    new KeyValuePair<byte[], Encoding>(utf8BOM.GetPreamble(), utf8BOM),
                };
            }
        }

        internal static string DecodeString(byte[] bytes, int lenght)
        {
            int encodingLookupLength = EncodingUtility.encodingLookup.Length;

            int preambleLength;
            for (int i = 0; i < encodingLookupLength; i++)
            {
                byte[] preamble = EncodingUtility.encodingLookup[i].Key;
                preambleLength = preamble.Length;
                if (lenght >= preambleLength)
                {
                    for (int j = 0; j < preambleLength; j++)
                    {
                        if (preamble[j] != bytes[j])
                        {
                            preambleLength = -1;
                        }
                    }

                    if (preambleLength < 0) continue;

                    try
                    {
                        Encoding tempEncoding = EncodingUtility.encodingLookup[i].Value;
                        return tempEncoding.GetString(bytes, preambleLength, lenght - preambleLength);
                    }
                    catch { };
                }
            }

            preambleLength = 0;
            Encoding encoding = EncodingUtility.targetEncoding;
            return encoding.GetString(bytes, preambleLength, lenght - preambleLength);
        }

        //public static string GetTextAssetString(TextAsset asset)
        //{
        //    if (asset == null)
        //    {
        //        LogSystem.Error("GetTextAssetString asset == null");
        //        return null;
        //    }

        //    byte[] byteData;
        //    var byteLen = GameUtil.GetTextAssetData(asset, out byteData);
        //    var text = DecodeString(byteData, byteLen);
        //    return text;
        //}

//        public static int GetTextAssetData(TextAsset asset, out byte[] data)
//        {
//            if (asset == null)
//            {
//                LogSystem.Error("GetTextAssetData asset == null");
//                data = null;
//                return 0;
//            }

//#if UNITY_2021_2_OR_NEWER
//            var byteArr = asset.GetData<byte>();
//            var byNum = byteArr.Length;
//            if (byNum > 0)
//            {
//                var cacheData = GlobalVariable.CheckGlobalCacheDataSize(byNum);
//                Unity.Collections.NativeArray<byte>.Copy(byteArr, cacheData, byNum);
//                data = cacheData;
//            }
//            else
//            {
//                data = null;
//                LogSystem.Error("GetTextAssetData byNum == 0");
//            }
//            byteArr.Dispose();
//            return byNum;
//#else
//            data = asset.bytes;
//            return data.Length;
//#endif
//        }

        public static bool IsAndroid()
        {
#if UNITY_WEBGL && TLBB_WXMINI && !UNITY_EDITOR
            return WXSystemInfo.platform == "android";
#else
            return Application.platform == RuntimePlatform.Android;
#endif
        }

        public static bool IsIOS()
        {
#if UNITY_WEBGL && TLBB_WXMINI && !UNITY_EDITOR
            return WXSystemInfo.platform == "ios";
#else
            return Application.platform == RuntimePlatform.IPhonePlayer;
#endif
        }

#if UNITY_WEBGL && TLBB_WXMINI && !UNITY_EDITOR
        static WeChatWASM.SystemInfo _WXSystemInfo;
        public static WeChatWASM.SystemInfo WXSystemInfo
        {
            get
            {
                if (_WXSystemInfo == null)
                {
                    _WXSystemInfo = WeChatWASM.WX.GetSystemInfoSync();
                }
                return _WXSystemInfo;
            }
        }

        [DllImport("__Internal")]
        private static extern void TLBB_SetScreenResolution(int width, int height);
#endif
        public static void SetResolution(int width, int height, bool fullscreen)
        {
            //TODO
#if UNITY_WEBGL && TLBB_WXMINI && !UNITY_EDITOR
            //TLBB_SetScreenResolution(width, height);
            //Screen.SetResolution(width, height, fullscreen);
#else
            Screen.SetResolution(width, height, fullscreen);
#endif
        }

#if UNITY_WEBGL
        static int _IsDeviceValid = -1;
#endif

        static int _targetFrameRate = 30;
        public static int targetFrameRate
        {
            set
            {
                _targetFrameRate = value;
#if UNITY_WEBGL && TLBB_WXMINI && !UNITY_EDITOR
                WeChatWASM.WX.SetPreferredFramesPerSecond(value);
#else
                Application.targetFrameRate = value;
#endif
            }

            get
            {
#if UNITY_WEBGL && TLBB_WXMINI && !UNITY_EDITOR
                return _targetFrameRate;
#else
                return Application.targetFrameRate;
#endif
            }
        }

        static bool IsWXDeviceValid()
        {
#if UNITY_WEBGL && TLBB_WXMINI && !UNITY_EDITOR
            if (_IsDeviceValid < 0)
            {
                _IsDeviceValid = 1;
                var info = WeChatWASM.WX.GetSystemInfoSync();
                if (info != null)
                {
                    if (string.IsNullOrEmpty(info.model)
                        && string.IsNullOrEmpty(info.SDKVersion)
                        && string.IsNullOrEmpty(info.platform)
                        && string.IsNullOrEmpty(info.system)
                        && Mathf.Approximately((float)info.screenHeight, 0)
                        && Mathf.Approximately((float)info.screenWidth, 0)
                        && Mathf.Approximately((float)info.pixelRatio, 0)
                        )
                    {
                        _IsDeviceValid = 0;
                    }
                }
                else
                {
                    _IsDeviceValid = 0;
                }
            }

            return _IsDeviceValid == 1;
#else
            return false;
#endif
        }

        public static bool IsPC()
        {
#if UNITY_EDITOR
            return true;
#elif UNITY_ANDROID || UNITY_IPHONE || UNITY_BLACKBERRY || UNITY_TVOS || UNITY_PSP2
            return false;
//#elif UNITY_WEBGL
//            if (IsWXDeviceValid())
//	        {
//                return false;
//	        }
//            else
//	        {
//                InitJs();
//                return jsDeviceType == 3;
//	        }
#else
            return SystemInfo.deviceType == DeviceType.Desktop;
#endif
        }

//#if UNITY_WEBGL && !UNITY_EDITOR
//        [DllImport("__Internal")]
//        private static extern int TLBB_GetDeviceType();

//        static int jsDeviceType = 0;
//        static bool isInitJs = false;

//        static void InitJs()
//        {
//            if (isInitJs)
//                return;
//            jsDeviceType = TLBB_GetDeviceType();
//            isInitJs = true;
//            LogSystem.Debug("jsDeviceType: {0}", jsDeviceType);
//        }
//#endif

//#if UNITY_WEBGL && !UNITY_EDITOR
//        public static void SetGUIFont()
//        {
//            var defFont = ResourceProxyManager.Instance.GetDefaultFont();
//            if (defFont != null)
//            {
//                GUI.skin.font = defFont;
//            }
//        }
//#endif
        static int mainThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
        public static bool IsMainThread
        {
            get { return System.Threading.Thread.CurrentThread.ManagedThreadId == mainThreadId; }
        }

        public static bool CheckMainThread(bool report = true)
        {
            var isMainThread = IsMainThread;
            if (!isMainThread && report)
            {
                LogAndReportException(new System.Exception("not main thread"), "CheckMainThread");
            }
            return isMainThread;
        }

        private static int? _ScreenWidth = null;//Physical size
        public static int ScreenWidth
        {
            get
            {
                if (!_ScreenWidth.HasValue)
                {
                    int width = 0;
#if UNITY_ANDROID && !UNITY_EDITOR
                    width = AndroidPlatform.NativityManagerActivity.CallStatic<int>("GetScreenWidth");
#endif
                    if (width <= 0)
                        width = Screen.width;

                    _ScreenWidth = width;
                }

                return _ScreenWidth.Value;
            }
        }

        static bool _ScreenSizeDirty = false;
        public static bool ScreenSizeDirty
        {
            set
            {
                _ScreenSizeDirty = value;
                if (_ScreenSizeDirty)
                {
                    _ScreenWidth = null;
                    _ScreenHeight = null;
                }
            }
        }

        private static int? _ScreenHeight = null;//Physical size
        public static int ScreenHeight
        {
            get
            {
                if (!_ScreenHeight.HasValue)
                {
                    int height = 0;
#if UNITY_ANDROID && !UNITY_EDITOR
                    height = AndroidPlatform.NativityManagerActivity.CallStatic<int>("GetScreenHeight");
#endif
                    if (height <= 0)
                        height = Screen.height;

                    _ScreenHeight = height;
                }

                return _ScreenHeight.Value;
            }
        }

        private static int? _NotchHeight = null;//Physical size
        public static int NotchHeight
        {
            get
            {
                if (!_NotchHeight.HasValue)
                {
                    int height = 0;
#if UNITY_ANDROID && !UNITY_EDITOR
                    height = AndroidPlatform.NativityManagerActivity.CallStatic<int>("GetNotchHeight");
#endif
                    _NotchHeight = height;
                }

                return _NotchHeight.Value;
            }
        }


        public static int NotchScreenHeight
        {
            get
            {
                //if (Screen.orientation == ScreenOrientation.LandscapeLeft)
                //{
                //    return (int)(ScreenAdapter.AdapterRectL.x * Screen.width);
                //}

                //if (Screen.orientation == ScreenOrientation.LandscapeRight)
                //{
                //    return (int)(ScreenAdapter.AdapterRectR.x * Screen.width);
                //}

                return 0;
            }
        }

#if OPTIMISE_XY_20210810
        public static Dictionary<ulong, string> cacheStrings = null;
        public static string GetBytePath(char[] buffer, int index, int len)
        {
            if (cacheStrings == null)
            {
                return new string(buffer, 0, len);
            }

            var k = Games.TLBB.Util.GameUtil.GetByteHashCode(buffer, index, len);
            string v;
            if (!cacheStrings.TryGetValue(k, out v))
            {
                v = new string(buffer, 0, len);
                cacheStrings[k] = v;
            }

            return v;
        }
#endif

        public static ulong GetByteHashCode(byte[] arr, int start, int length)
        {
            ulong k = 14695981039346656037;
            int end = start + length;
            byte data;
            for (var index = start; index < end; index++)
            {
                data = arr[index];
                k *= 1099511628211;
                k ^= data;
            }
            return k;
        }

        public static ulong GetByteHashCode(char[] arr, int start, int length)
        {
            ulong k = 14695981039346656037;
            int end = start + length;
            byte data;
            for (var index = start; index < end; index++)
            {
                data = (byte)arr[index];
                k *= 1099511628211;
                k ^= data;
            }
            return k;
        }

        //unsafe public static ulong GetByteHashCode(IntPtr arr, int start, int length)
        //{
        //    if (IntPtr.Zero == arr)
        //    {
        //        return 0;
        //    }

        //    byte* ptr = (byte*)arr.ToPointer();
        //    ulong k = 14695981039346656037;
        //    int end = start + length;
        //    byte data;
        //    for (var index = start; index < end; index++)
        //    {
        //        data = *(ptr + index);
        //        k *= 1099511628211;
        //        k ^= data;
        //    }
        //    return k;
        //}

//        public static void GetWebPictureAndSave(UITexture uiTex, string webUrl, string localUrl = null, Texture2D defaultTex = null) {
//            if (!String.IsNullOrEmpty(localUrl))
//            {
//                StringBuilder filePath = new StringBuilder();
//                if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
//                {
//                    filePath.Append(Application.persistentDataPath);
//                }
//                else if (Application.platform == RuntimePlatform.WindowsEditor)
//                {
//                    filePath.Append(Application.dataPath);
//                    filePath = filePath.Replace("/Assets", null);
//                }
//                filePath.Append("/");
//                filePath.Append(localUrl);
//#if GAMEDEBUG
//                LogSystem.Debug("----GameUtil:GetWebPictureAndSave----localFilePath = {0}", filePath.ToString());
//#endif
//                string path = filePath.ToString();
//                bool isHave = System.IO.File.Exists(path);
//                if (isHave)
//                {
//                    GameManager.Instance.StartCoroutine(LoadImage(path, (Texture2D tex) =>
//                    {
//                        if (tex == null)
//                        {
//#if GAMEDEBUG
//                            LogSystem.Debug("--GameUtil:GetWebPictureAndSave--isHave--localFilePath load fail!!! Ready to download from webUrl={0}", webUrl);
//#endif
//                            GameManager.Instance.StartCoroutine(GetWebPicture(webUrl, (Texture2D webtex)=> {
//                                if (webtex == null)
//                                {
//                                    if (defaultTex != null)
//                                    {
//                                        if (uiTex != null)
//                                        {
//                                            uiTex.mainTexture = defaultTex;
//                                        }
//                                    }
//#if GAMEDEBUG
//                                    LogSystem.Debug("--GameUtil:GetWebPictureAndSave--isHave--localFilePath load fail--webUrl load failed!!!");
//#endif
//                                }
//                                else
//                                {
//                                    if (uiTex != null) {
//                                        uiTex.mainTexture = webtex;
//                                        CEventSender.SendEvent(LuaEvent.AutoDestroyTexture, uiTex, webtex);
//                                        SaveTexture(webtex, localUrl);
//                                    }
//                                    else
//                                    {
//                                        GameObject.DestroyImmediate(webtex);
//                                    }
//#if GAMEDEBUG
//                                    LogSystem.Debug("--GameUtil:GetWebPictureAndSave--isHave--localFilePath load fail--webUrl load Success!!!");
//#endif
//                                }
//                            }));
//                        }
//                        else//(tex == null)
//                        {
//                            if (uiTex != null) {
//                                uiTex.mainTexture = tex;
//                                CEventSender.SendEvent(LuaEvent.AutoDestroyTexture, uiTex, tex);
//                            }
//                            else
//                            {
//                                GameObject.DestroyImmediate(tex);
//                            }
//#if GAMEDEBUG
//                            LogSystem.Debug("--GameUtil:GetWebPictureAndSave--isHave--localFilePath load Success!!!");
//#endif
//                        }
//                    }));
//                }//isHave
//                else {
//#if GAMEDEBUG
//                    LogSystem.Debug("--GameUtil:GetWebPictureAndSave--isHave = false--Ready to download from webUrl={0}", webUrl);
//#endif
//                    GameManager.Instance.StartCoroutine(GetWebPicture(webUrl, (Texture2D webtex) => {
//                        if (webtex == null) {
//                            if (defaultTex != null) {
//                                if (uiTex != null)
//                                {
//                                    uiTex.mainTexture = defaultTex;
//                                }
//                            }
//#if GAMEDEBUG
//                            LogSystem.Debug("--GameUtil:GetWebPictureAndSave----isHave = false--webUrl load failed!!!");
//#endif
//                        }
//                        else {
//                            if (uiTex != null)
//                            {
//                                uiTex.mainTexture = webtex;
//                                CEventSender.SendEvent(LuaEvent.AutoDestroyTexture, uiTex, webtex);
//                                SaveTexture(webtex, localUrl);
//                            }
//                            else {
//                                GameObject.DestroyImmediate(webtex);
//                            }
//#if GAMEDEBUG
//                            LogSystem.Debug("--GameUtil:GetWebPictureAndSave----isHave = false--webUrl load Success!!!");
//#endif
//                        }
//                    }));
//                }
//            }
//            else {//localUrl != null
//#if GAMEDEBUG
//                LogSystem.Debug("--GameUtil:GetWebPictureAndSave----localFilePath = null---Ready to download from webUrl={0}", webUrl);
//#endif
//                GameManager.Instance.StartCoroutine(GetWebPicture(webUrl, (Texture2D webtex) =>
//                {
//                    if (webtex == null)
//                    {
//                        if (defaultTex != null)
//                        {
//                            if (uiTex != null)
//                            {
//                                uiTex.mainTexture = defaultTex;
//                            }
//                        }
//#if GAMEDEBUG
//                        LogSystem.Debug("--GameUtil:GetWebPictureAndSave--localFilePath = null--webUrl load failed!!!");
//#endif
//                    }
//                    else
//                    {
//                        if (uiTex != null)
//                        {
//                            uiTex.mainTexture = webtex;
//                            CEventSender.SendEvent(LuaEvent.AutoDestroyTexture, uiTex, webtex);
//                        }
//                        else {
//                            GameObject.DestroyImmediate(webtex);
//                        }
//#if GAMEDEBUG
//                        LogSystem.Debug("--GameUtil:GetWebPictureAndSave--localFilePath = null---webUrl load Success!!!");
//#endif
//                    }
//                }));

//            }//localUrl != null

//        }

//        public static IEnumerator GetWebPicture( string url, Action<Texture2D> callBack) {
//            WWW downLoadTexture = new WWW(url);
//            yield return downLoadTexture;
//            if (downLoadTexture.error != null)
//            {
//                if (callBack != null) {

//                    try
//                    {
//                        CEventSender.SendEvent(LuaEvent.WebPictureEnd,1);
//                        callBack(null);
//                    }
//                    catch (System.Exception e)
//                    {
//                        LogSystem.Error("GameUtil:GetWebPicture----callBack----null----e.Message={0}", e.Message);
//                    }
//                }
//#if GAMEDEBUG
//                LogSystem.Error("---------GameUtil:GetWebPicture------downIcon.error  = {0}", downLoadTexture.error);
//#endif
//            }
//            else
//            {
//                if (callBack != null)
//                {
//                    try
//                    {
//                        CEventSender.SendEvent(LuaEvent.WebPictureEnd, 0);
//                        callBack(downLoadTexture.texture);
//                    }
//                    catch (System.Exception e)
//                    {
//                        LogSystem.Error("GameUtil:GetWebPicture----callBack----e.Message={0}", e.Message);
//                    }
//                }
//#if GAMEDEBUG
//                LogSystem.Debug("---------GameUtil:GetWebPicture------Picture finish!");
//#endif
//            }
//        }

        public static void SaveTexture(Texture2D tex,string path) {
            path = path.Replace("\\", "/");
            if (!path.StartsWith("/")) {
                path = "/" + path;
            }
            StringBuilder filePath = new StringBuilder();
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                filePath.Append(Application.persistentDataPath);
            }
            else if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                filePath.Append(Application.dataPath);
                filePath = filePath.Replace("/Assets", null);
            }
            filePath.Append(path);

            path = path.Replace("\\", "/");

            string destination = Path.GetDirectoryName(filePath.ToString());
            try {
#if GAMEDEBUG
                LogSystem.Debug("----GameUtil:SaveTexture----filePath = {0}", filePath.ToString());
                LogSystem.Debug("----GameUtil:SaveTexture----destination = {0}", destination);
#endif
                if (!Directory.Exists(destination))
                {
                    Directory.CreateDirectory(destination);
                }
                byte[] bytes = tex.EncodeToPNG();
                tex.Compress(true);
                tex.Apply();
#if UNITY_EDITOR

                File.WriteAllBytes(filePath.ToString(), bytes);
#else

#if UNITY_IPHONE
		
			if(Application.platform == RuntimePlatform.IPhonePlayer) 
			{
                File.WriteAllBytes(filePath.ToString(), bytes);
				UnityEngine.iOS.Device.SetNoBackupFlag(filePath.ToString());
			}
			
#elif UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {

                File.WriteAllBytes(filePath.ToString(), bytes);
            }
#endif

#endif
            }
            catch (System.Exception e) {
                LogSystem.Error("GameUtil:SaveTexture----e.Message={0}", e.Message);
            }


        }

        private static IEnumerator LoadImage(string path,Action<Texture2D> callBack) {
#if GAMEDEBUG
            LogSystem.Debug("----GameUtil:LoadImage---path = {0}", path);
#endif
            path = "file://" + path;
            WWW www = new WWW(path);
            yield return www;
            if (www.isDone && string.IsNullOrEmpty(www.error))
            {
                try
                {
#if GAMEDEBUG
                    LogSystem.Debug("----GameUtil:LoadImage---isDone---path = {0}", path);
#endif
                    Texture2D texture = www.texture;
                    if (callBack != null)
                    {
                        callBack(texture);
                    }
                    www.Dispose();
                }
                catch (System.Exception e)
                {
                    LogSystem.Error("GameUtil:LoadIamge----e.Message={0}", e.Message);
                }
            }
            else {
                LogSystem.Error("GameUtil:LoadIamge Error!!! www.error={0}", www.error);
                if (callBack != null)
                {
                    try
                    {
                        callBack(null);
                    }catch (System.Exception e)
                    {
                        LogSystem.Error("GameUtil:LoadIamge----callBack----null----e.Message={0}", e.Message);
                    }

                }
                yield break;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Url">请求的URL</param>
        /// <param name="timeout">请求的超时时间</param>
        /// <returns></returns>
        public static string HttpGet(string Url, int? timeout)
        {
            string retString = "";
            //LogSystem.Debug("----------GameUtil.HttpGet-------------Url={0}", Url);
            try
            {
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                HttpWebRequest request = null;
                if (Url.StartsWith("Https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    request = (HttpWebRequest)WebRequest.Create(Url);
                    request.ProtocolVersion = HttpVersion.Version11;
                }
                else
                {
                    request = (HttpWebRequest)WebRequest.Create(Url);
                }
                //LogSystem.Debug("----------GameUtil.HttpGet-------------request.RequestUri.AbsolutePath={0}", request.RequestUri.AbsolutePath);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                if (timeout.HasValue)
                {
                    request.Timeout = timeout.Value;
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                //LogSystem.Debug("----------GameUtil.HttpGet-------------retString = {0}", retString);
                //CEventSender.SendEvent(LuaEvent.HttpGetResponseMsg, 0, retString);
            } catch (System.Exception e) {
                LogSystem.Error("GameUtil:HttpGet--Exctption:{0}", e.ToString());
#if GAMEDEBUG
                CEventSender.SendEvent(LuaEvent.HttpGetResponseMsg, 1, e.ToString());
#endif
            }
            return retString;
        }
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Url">请求的URL</param>
        /// <param name="postDataStr">post</param>
        /// <param name="timeout">请求的超时时间</param>
        /// <returns></returns>
        public static string HttpPost(string Url, string postDataStr, int? timeout)
        {
            string retString = "";
            StreamWriter writer = null;
            StreamReader reader = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postDataStr.Length;
                writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
                writer.Write(postDataStr);
                writer.Flush();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string encoding = response.ContentEncoding;
                if (timeout.HasValue)
                {
                    request.Timeout = timeout.Value;
                }
                if (encoding == null || encoding.Length < 1)
                {
                    encoding = "UTF-8"; //默认编码 
                }

                reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
                retString = reader.ReadToEnd();
                //LogSystem.Debug("----------GameUtil.HttpPost-------------retString = {0}", retString);
                //CEventSender.SendEvent(LuaEvent.HttpPostResponseMsg, 0, retString);
            }
            catch (System.Exception e) {
                LogSystem.Error("GameUtil:HttpPost--Exctption:{0}", e.ToString());
#if GAMEDEBUG
                CEventSender.SendEvent(LuaEvent.HttpPostResponseMsg, 1, e.ToString());
#endif
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }

            return retString;
        }

        public static IEnumerator HttpPostRequest_U3D(string url, WWWForm data)
        {
            WWW postReq = new WWW(url, data);
            yield return postReq;
            if (postReq.error != null)
            {
                LogSystem.Error("ERROR!!!-----GameUtil:HttpPostRequestReturnString-----WWW ERROR = {0}", postReq.error);
#if GAMEDEBUG
                CEventSender.SendEvent(LuaEvent.HttpPostResponseMsg, 1, postReq.error);
#endif
            }
            else
            {
                string result = postReq.text;
                //LogSystem.Debug("----------GameUtil.HttpPostRequest_U3D-------------result = {0}", result);
                //CEventSender.SendEvent(LuaEvent.HttpPostResponseMsg, 0,result);
            }
        }




        public static IEnumerator HttpGetRequest_U3D(string url) {
            WWW getReq = new WWW(url);
            yield return getReq;
            if (getReq.error != null)
            {
                LogSystem.Error("ERROR!!!-----GameUtil:HttpPostRequestReturnString-----WWW ERROR = {0}", getReq.error);
#if GAMEDEBUG
                CEventSender.SendEvent(LuaEvent.HttpGetResponseMsg, 1, getReq.error);
#endif
            }
            else
            {
                string result = getReq.text;
                //LogSystem.Debug("----------GameUtil.HttpGetRequest_U3D-------------result = {0}", result);
                //CEventSender.SendEvent(LuaEvent.HttpGetResponseMsg, 0,result);
            }
        }

        private static int[] s_2N = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 67108864, 134217728, 268435456 };
        public static int GetNearest2N(int cur)
        {
            if (cur == 0) cur = 1;
            int len = s_2N.Length;
            for (int i = 0; i < len; i++)
            {
                if (cur >= s_2N[i])
                {
                    if (cur < s_2N[i] * 2)
                    {
                        return s_2N[i] * 2;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return cur * 2;
        }
        private static T PoolNew<T>(Queue<T> p) where T : new()
        {
            if (p != null)
            {
                if (p.Count > 0)
                {
                    T ret = p.Dequeue();
                    return ret;
                }
            } 
            return new T();
        }

        private static void PoolDel<T>(ref T needdel, Queue<T> p) where T : class
        {
            if (needdel != null)
            {
                if (p != null)
                {
                    if (p.Count < 100)
                    {
                        p.Enqueue(needdel);
                    }
                }
                needdel = null;
            }
        }

        
        //
        //public static Queue<I2.TextAnimation.SE_AnimSequence_Scale> SE_AnimSequence_ScalePool = new Queue<I2.TextAnimation.SE_AnimSequence_Scale>(20);
        //
        //public static I2.TextAnimation.SE_AnimSequence_Scale PoolNewSE_AnimSequence_Scale()
        //{
        //    return PoolNew<I2.TextAnimation.SE_AnimSequence_Scale>(SE_AnimSequence_ScalePool);
        //}
        //
        //public static void PoolDelSE_AnimSequence_Scale(ref I2.TextAnimation.SE_AnimSequence_Scale needdel)
        //{
        //    if (needdel != null)
        //    {
        //        needdel.ReleaseByPool();
        //    }
        //    PoolDel<I2.TextAnimation.SE_AnimSequence_Scale>(ref needdel, SE_AnimSequence_ScalePool);
        //}



        //
        //public static Queue<I2.TextAnimation.SE_AnimSequence_Rotation> SE_AnimSequence_RotationPool = new Queue<I2.TextAnimation.SE_AnimSequence_Rotation>(20);
        //
        //public static I2.TextAnimation.SE_AnimSequence_Rotation PoolNewSE_AnimSequence_Rotation()
        //{
        //    return PoolNew<I2.TextAnimation.SE_AnimSequence_Rotation>(SE_AnimSequence_RotationPool);
        //}
        //
        //public static void PoolDelSE_AnimSequence_Rotation(ref I2.TextAnimation.SE_AnimSequence_Rotation needdel)
        //{
        //    if (needdel != null)
        //    {
        //        needdel.ReleaseByPool();
        //    }
        //    PoolDel<I2.TextAnimation.SE_AnimSequence_Rotation>(ref needdel, SE_AnimSequence_RotationPool);
        //}


        //
        //public static Queue<I2.TextAnimation.SE_AnimSequence_Position> SE_AnimSequence_PositionPool = new Queue<I2.TextAnimation.SE_AnimSequence_Position>(20);
        //
        //public static I2.TextAnimation.SE_AnimSequence_Position PoolNewSE_AnimSequence_Position()
        //{
        //    return PoolNew<I2.TextAnimation.SE_AnimSequence_Position>(SE_AnimSequence_PositionPool);
        //}
        //
        //public static void PoolDelSE_AnimSequence_Position(ref I2.TextAnimation.SE_AnimSequence_Position needdel)
        //{
        //    if (needdel != null)
        //    {
        //        needdel.ReleaseByPool();
        //    }
        //    PoolDel<I2.TextAnimation.SE_AnimSequence_Position>(ref needdel, SE_AnimSequence_PositionPool);
        //}



        //
        //public static Queue<I2.TextAnimation.SE_AnimSequence_Float> SE_AnimSequence_FloatPool = new Queue<I2.TextAnimation.SE_AnimSequence_Float>(20);
        //
        //public static I2.TextAnimation.SE_AnimSequence_Float PoolNewSE_AnimSequence_Float()
        //{
        //    return PoolNew<I2.TextAnimation.SE_AnimSequence_Float>(SE_AnimSequence_FloatPool);
        //}
        //
        //public static void PoolDelSE_AnimSequence_Float(ref I2.TextAnimation.SE_AnimSequence_Float needdel)
        //{
        //    if (needdel != null)
        //    {
        //        needdel.ReleaseByPool();
        //    }
        //    PoolDel<I2.TextAnimation.SE_AnimSequence_Float>(ref needdel, SE_AnimSequence_FloatPool);
        //}



        //
        //public static Queue<I2.TextAnimation.SE_AnimSequence_Color> SE_AnimSequence_ColorPool = new Queue<I2.TextAnimation.SE_AnimSequence_Color>(20);
        //
        //public static I2.TextAnimation.SE_AnimSequence_Color PoolNewSE_AnimSequence_Color()
        //{
        //    return PoolNew<I2.TextAnimation.SE_AnimSequence_Color>(SE_AnimSequence_ColorPool);
        //}
        //
        //public static void PoolDelSE_AnimSequence_Color(ref I2.TextAnimation.SE_AnimSequence_Color needdel)
        //{
        //    if (needdel != null)
        //    {
        //        needdel.ReleaseByPool();
        //    }
        //    PoolDel<I2.TextAnimation.SE_AnimSequence_Color>(ref needdel, SE_AnimSequence_ColorPool);
        //}


        //
        //public static Queue<I2.TextAnimation.SE_AnimSequence_Alpha> SE_AnimSequence_AlphaPool = new Queue<I2.TextAnimation.SE_AnimSequence_Alpha>(20);
        //
        //public static I2.TextAnimation.SE_AnimSequence_Alpha PoolNewSE_AnimSequence_Alpha()
        //{
        //    return PoolNew<I2.TextAnimation.SE_AnimSequence_Alpha>(SE_AnimSequence_AlphaPool);
        //}
        //
        //public static void PoolDelSE_AnimSequence_Alpha(ref I2.TextAnimation.SE_AnimSequence_Alpha needdel)
        //{
        //    if (needdel != null)
        //    {
        //        needdel.ReleaseByPool();
        //    }
        //    PoolDel<I2.TextAnimation.SE_AnimSequence_Alpha>(ref needdel, SE_AnimSequence_AlphaPool);
        //}



        //
        //public static Queue<I2.TextAnimation.SE_Animation> SE_AnimationPool = new Queue<I2.TextAnimation.SE_Animation>(20);
        //
        //public static I2.TextAnimation.SE_Animation PoolNewSE_Animation()
        //{
        //    return PoolNew<I2.TextAnimation.SE_Animation>(SE_AnimationPool);
        //}
        //
        //public static void PoolDelSE_Animation(ref I2.TextAnimation.SE_Animation needdel)
        //{
        //    if (needdel != null)
        //    {
        //        needdel.ReleaseByPool();
        //    }
        //    PoolDel<I2.TextAnimation.SE_Animation>(ref needdel, SE_AnimationPool);
        //}

        
        
        //
        //public static Queue<SwingData> SwingDataPool = new Queue<SwingData>(0);
        //public static int CurUsedSwingDataCount = 0;
        //public static int MaxUsedSwingDataCount = -1;

        //
        //public static SwingData PoolNewSwingData()
        //{
        //    if(MaxUsedSwingDataCount == -1)
        //    {
        //        MaxUsedSwingDataCount = Games.TLBB.Common.SystemCFG.Instance.GetInt("General", "SwingNum");
        //    }
        //    if (CurUsedSwingDataCount < MaxUsedSwingDataCount)
        //    {
        //        CurUsedSwingDataCount++;
        //        return PoolNew<SwingData>(SwingDataPool);
        //    }
        //    return null;
        //}
        //
        //public static void PoolDelSwingData(ref SwingData needdel)
        //{
        //    if (needdel != null)
        //    {
        //        needdel.Release();
        //        if(CurUsedSwingDataCount>=0)    CurUsedSwingDataCount--;
        //    }
        //    PoolDel<SwingData>(ref needdel, SwingDataPool);
        //}

        //
        //public static Queue<SwimWeaponData> SwimFixedDataPool = new Queue<SwimWeaponData>(100);
        //
        //public static SwimWeaponData PoolNewSwimFixedData()
        //{
        //    return PoolNew<SwimWeaponData>(SwimFixedDataPool);
        //}
        //
        //public static void PoolDelSwimFixedData(ref SwimWeaponData needdel)
        //{
        //    if (needdel != null)
        //    {
        //        needdel.Release();
        //    }

        //    PoolDel<SwimWeaponData>(ref needdel, SwimFixedDataPool);
        //}

        //private static int currUsedCound = 0;
        //
        //public static Queue<GCChat> GCChatPool = new Queue<GCChat>(100);
        //
        //public static GCChat PoolNewGCChat()
        //{
        //    //currUsedCound++;
        //    //Debug.LogError("===============New,currUsedCound:" + currUsedCound + " GCChatPool.Count:" + GCChatPool.Count);
        //    return PoolNew<GCChat>(GCChatPool);
        //}
        //
        //public static void PoolDelGCChat(ref GCChat needdel)
        //{
        //    if (needdel != null)
        //    {
        //        needdel.Clear();
        //    }
        //    //currUsedCound--;
        //    PoolDel<GCChat>(ref needdel, GCChatPool);
        //    //Debug.LogError("===============Del,currUsedCound:" + currUsedCound + " GCChatPool.Count:" + GCChatPool.Count);
        //}

        //private static int currUsedCount = 0;
        public static Queue<UISpriteData> UISpriteDataPool = new Queue<UISpriteData>(100);
        public static UISpriteData PoolNewUISpriteData()
        {
            //currUsedCount++;
            //Debug.LogError("====增加：" + currUsedCount + " total:" + UISpriteDataPool.Count);
            return PoolNew<UISpriteData>(UISpriteDataPool);
        }
        //public static void PoolDelUISpriteData(ref UISpriteData needdel)
        //{
        //    if (null != needdel)
        //    {
        //        needdel.Release();
        //    }

        //    //if (currUsedCount > 0)
        //    //{
        //    //    currUsedCount--;
        //    //}

        //    //Debug.LogError("====回收："+ currUsedCount + " total:" + UISpriteDataPool.Count);
        //    PoolDel<UISpriteData>(ref needdel, UISpriteDataPool);
        //}

  //      
  //      public static Queue<Games.TLBB.Data.SData_Pet> SData_PetPool = new Queue<Games.TLBB.Data.SData_Pet>(20);
  //      
  //      public static Games.TLBB.Data.SData_Pet PoolNewSData_Pet()
  //      {
  //          return PoolNew<Games.TLBB.Data.SData_Pet>(SData_PetPool);
  //      }
  //      
  //      public static void PoolDelSData_Pet(ref Games.TLBB.Data.SData_Pet needdel)
  //      {
  //          if (needdel != null)
  //          {
  //              needdel.Release();
  //          }
  //          PoolDel<Games.TLBB.Data.SData_Pet>(ref needdel, SData_PetPool);
  //      }

  //      
  //      public static Queue<Games.TLBB.Data.SData_Item> SData_ItemPool = new Queue<Games.TLBB.Data.SData_Item>(100);
  //      
  //      public static Games.TLBB.Data.SData_Item PoolNewSData_Item()
  //      {
  //          return PoolNew<Games.TLBB.Data.SData_Item>(SData_ItemPool);
  //      }
  //      
  //      public static void PoolDelSData_Item(ref Games.TLBB.Data.SData_Item needdel)
  //      {
  //          if(needdel!=null)
  //          {
  //              needdel.CleanUp();
  //          }
  //          PoolDel<Games.TLBB.Data.SData_Item>(ref needdel, SData_ItemPool);
  //      }

  //      
  //      public static Queue<Games.TLBB.Manager.cFashionItemVO> cFashionItemVOPool = new Queue<Games.TLBB.Manager.cFashionItemVO>(100);
  //      

        
  //      public static Games.TLBB.Manager.cFashionItemVO PoolNewChildrenFashionItemVO()
  //      {
  //          return PoolNew<Games.TLBB.Manager.cFashionItemVO>(cFashionItemVOPool);
  //      }
  //      
  //      public static void PoolDelChildrenFashionItemVO(ref Games.TLBB.Manager.cFashionItemVO needdel)
  //      {
  //          if (needdel != null) {
  //              needdel.CleanUp();
  //          }
  //          PoolDel<Games.TLBB.Manager.cFashionItemVO>(ref needdel, cFashionItemVOPool);
  //      }
     


  //      
  //      public static Queue<Games.TLBB.Manager.FashionItemVO> FashionItemVOPool = new Queue<Games.TLBB.Manager.FashionItemVO>(100);
  //      
  //      public static Games.TLBB.Manager.FashionItemVO PoolNewFashionItemVO()
  //      {
  //          return PoolNew<Games.TLBB.Manager.FashionItemVO>(FashionItemVOPool);
  //      }
  //      
  //      public static void PoolDelFashionItemVO(ref Games.TLBB.Manager.FashionItemVO needdel)
  //      {
  //          if (needdel != null)
  //          {
  //              needdel.CleanUp();
  //          }
  //          PoolDel<Games.TLBB.Manager.FashionItemVO>(ref needdel, FashionItemVOPool);
  //      }

  //      
  //      public static Queue<FunitureInfoVO> FurnitureItemVOPool = new Queue<FunitureInfoVO>(100);
  //      
  //      public static FunitureInfoVO PoolNewFurnitureItemVO()
  //      {
  //          return PoolNew<FunitureInfoVO>(FurnitureItemVOPool);
  //      }
  //      
  //      public static void PoolDelFashionItemVO(ref FunitureInfoVO needdel)
  //      {
  //          if (needdel != null)
  //          {
  //              needdel.CleanUp();
  //          }
  //          PoolDel<FunitureInfoVO>(ref needdel, FurnitureItemVOPool);
  //      }

  //      
  //      public static Queue<Games.TLBB.Lua.ItemNum> ItemNumPool = new Queue<Games.TLBB.Lua.ItemNum>(100);
  //      
  //      public static Games.TLBB.Lua.ItemNum PoolNewItemNum()
  //      {
  //          return PoolNew<Games.TLBB.Lua.ItemNum>(ItemNumPool);
  //      }
  //      
  //      public static void PoolDelItemNum(ref Games.TLBB.Lua.ItemNum needdel)
  //      {
  //          PoolDel<Games.TLBB.Lua.ItemNum>(ref needdel, ItemNumPool);
  //      }
  //      //2017-10-15 sunyu BuffVo优化
  //      
  //      public static Queue<Games.TLBB.Modules.Skill.BuffVo> BuffVoPool = new Queue<Games.TLBB.Modules.Skill.BuffVo>(100);
		//public static Dictionary<int, int> BuffVoHashDic = new Dictionary<int, int>();
  //      
  //      public static Games.TLBB.Modules.Skill.BuffVo PoolNewBuffVo()
  //      {
  //          Games.TLBB.Modules.Skill.BuffVo n = PoolNew<Games.TLBB.Modules.Skill.BuffVo>(BuffVoPool);
  //          n.CleanUp();
		//	if (BuffVoHashDic.ContainsKey(n.GetHashCode()))
		//	{
		//		BuffVoHashDic.Remove(n.GetHashCode());
		//	}
  //          return n;
  //      }
  //      
  //      public static void PoolDelBuffVo(ref Games.TLBB.Modules.Skill.BuffVo needdel)
  //      {
  //          if (needdel != null)
  //          {
		//			if(BuffVoHashDic.ContainsKey(needdel.GetHashCode()))
		//			{
		//				LogSystem.Error("GameUtil: PoolDelBuffVo 重复回收Buff ConfigId: {0}",needdel.configId);
		//				return;
		//			}
		//			BuffVoHashDic[needdel.GetHashCode()] = 1;
		//		needdel.CleanUp();
  //          }
  //          PoolDel<Games.TLBB.Modules.Skill.BuffVo>(ref needdel, BuffVoPool);
  //      }
        
  //      //2017-10-13 sunyu TeamShowVOList优化
  //      
  //      public static Queue<Games.TLBB.Manager.TeamShowVOInfo> TeamShowVOInfoPool = new Queue<Games.TLBB.Manager.TeamShowVOInfo>(30);
  //      
  //      public static Games.TLBB.Manager.TeamShowVOInfo PoolNewTeamShowVOInfo()
  //      {
  //          return PoolNew<Games.TLBB.Manager.TeamShowVOInfo>(TeamShowVOInfoPool);
  //      }
  //      
  //      public static void PoolDelTeamShowVOInfo(ref Games.TLBB.Manager.TeamShowVOInfo needdel)
  //      {
  //          if (needdel != null)
  //          {
  //              needdel.CleanUp();
  //          }
  //          PoolDel<Games.TLBB.Manager.TeamShowVOInfo>(ref needdel, TeamShowVOInfoPool);
  //      }

  //      
  //      public static Queue<Games.TLBB.Modules.Skill.SkillHitAxis.HitInfo> HitInfoPool = new Queue<Games.TLBB.Modules.Skill.SkillHitAxis.HitInfo>(100);
  //      
  //      public static Games.TLBB.Modules.Skill.SkillHitAxis.HitInfo PoolNewHitInfo()
  //      {
  //          return PoolNew<Games.TLBB.Modules.Skill.SkillHitAxis.HitInfo>(HitInfoPool);
  //      }
  //      
  //      public static void PoolDelHitInfo(ref Games.TLBB.Modules.Skill.SkillHitAxis.HitInfo needdel)
  //      {
  //          if (needdel != null)
  //          {
  //              needdel.CleanMemory();
  //          }
  //          PoolDel<Games.TLBB.Modules.Skill.SkillHitAxis.HitInfo>(ref needdel, HitInfoPool);
  //      }

  //      
  //      public static Queue<Games.TLBB.Modules.Skill.SkillHitAxis> SkillHitAxisPool = new Queue<Games.TLBB.Modules.Skill.SkillHitAxis>(100);
  //      
  //      public static Games.TLBB.Modules.Skill.SkillHitAxis PoolNewSkillHitAxis()
  //      {
  //          return PoolNew<Games.TLBB.Modules.Skill.SkillHitAxis>(SkillHitAxisPool);
  //      }
  //      
  //      public static void PoolDelSkillHitAxis(ref Games.TLBB.Modules.Skill.SkillHitAxis needdel)
  //      {
  //          if (needdel != null)
  //          {
  //              needdel.CleanMemory();
  //          }
  //          PoolDel<Games.TLBB.Modules.Skill.SkillHitAxis>(ref needdel, SkillHitAxisPool);
  //      }
  //      
  //      public static Queue<Games.TLBB.Render.RenderEffect> RenderEffectsPool = new Queue<Games.TLBB.Render.RenderEffect>(100);
  //      
  //      public static Games.TLBB.Render.RenderEffect PoolNewRenderEffect()
  //      {
  //          if (RenderEffectsPool != null)
  //          {
  //              if (RenderEffectsPool.Count > 0)
  //              {
  //                  Games.TLBB.Render.RenderEffect ret = RenderEffectsPool.Dequeue();
  //                  return ret;
  //              }
  //          }
  //          return new Games.TLBB.Render.RenderEffect(-1);
  //      }
  //      
  //      public static void PoolDelRenderEffect(ref Games.TLBB.Render.RenderEffect needdel)
  //      {
  //          PoolDel<Games.TLBB.Render.RenderEffect>(ref needdel, RenderEffectsPool);
  //      }
  //      
  //      public static Queue<List<Vector3>> MovePointsPool = new Queue<List<Vector3>>(100);
  //      
  //      public static List<Vector3> PoolNewMovePoints()
  //      {
  //          if (MovePointsPool != null)
  //          {
  //              if (MovePointsPool.Count > 0)
  //              {
  //                  List<Vector3> ret = MovePointsPool.Dequeue();
  //                  return ret;
  //              }
  //          }
  //          return new List<Vector3>(Games.TLBB.Global.GameDefine_GlobalVar.MaxPathNode);
  //      }
  //      
  //      public static void PoolDelMovePoints(ref List<Vector3> needdel)
  //      {
  //          if (needdel != null)
  //          {
  //              needdel.Clear();
  //              PoolDel<List<Vector3>>(ref needdel, MovePointsPool);
  //          }
  //      }

        public static Queue<System.Object[]> ObjectArray1_p = new Queue<System.Object[]>(100);
        public static System.Object[] PoolNewObjectArray1()
        {
            if (ObjectArray1_p != null)
            {
                if (ObjectArray1_p.Count > 0)
                {
                    System.Object[] ret = ObjectArray1_p.Dequeue();
                    return ret;
                }
            }
            return new System.Object[1];
        }
        public static void PoolDelObjectArray1(ref System.Object[] needdel)
        {
            if (needdel != null)
            {
                int len = needdel.Length;
                for(int i =0;i<len;i++)
                {
                    needdel[i] = null;
                }
                PoolDel<System.Object[]>(ref needdel, ObjectArray1_p);
            }
        }
        public static Queue<System.Object[]> ObjectArray2_p = new Queue<System.Object[]>(100);
        public static System.Object[] PoolNewObjectArray2()
        {
            if (ObjectArray2_p != null)
            {
                if (ObjectArray2_p.Count > 0)
                {
                    System.Object[] ret = ObjectArray2_p.Dequeue();
                    return ret;
                }
            }
            return new System.Object[2];
        }
        public static void PoolDelObjectArray2(ref System.Object[] needdel)
        {
            if (needdel != null)
            {
                int len = needdel.Length;
                for(int i =0;i<len;i++)
                {
                    needdel[i] = null;
                }
                PoolDel<System.Object[]>(ref needdel, ObjectArray2_p);
            }
        }

        
        public  static Queue<System.Object[]> ObjectArray3_p = new Queue<System.Object[]>(100);
        public static System.Object[] PoolNewObjectArray3()
        {
            if (ObjectArray3_p != null)
            {
                if (ObjectArray3_p.Count > 0)
                {
                    System.Object[] ret = ObjectArray3_p.Dequeue();
                    return ret;
                }
            }
            return new System.Object[3];
        }
        public static void PoolDelObjectArray3(ref System.Object[] needdel)
        {
            if (needdel != null)
            {
                int len = needdel.Length;
                for(int i =0;i<len;i++)
                {
                    needdel[i] = null;
                }
                PoolDel<System.Object[]>(ref needdel, ObjectArray3_p);
            }
        }
        public  static Queue<System.Object[]> ObjectArray4_p = new Queue<System.Object[]>(100);
        public static System.Object[] PoolNewObjectArray4()
        {
            if (ObjectArray4_p != null)
            {
                if (ObjectArray4_p.Count > 0)
                {
                    System.Object[] ret = ObjectArray4_p.Dequeue();
                    return ret;
                }
            }
            return new System.Object[4];
        }
        public static void PoolDelObjectArray4(ref System.Object[] needdel)
        {
            if (needdel != null)
            {
                int len = needdel.Length;
                for(int i =0;i<len;i++)
                {
                    needdel[i] = null;
                }
                PoolDel<System.Object[]>(ref needdel, ObjectArray4_p);
            }
        }
        public  static Queue<HashSet<UnityEngine.Object>> HashSetUnityObjectPool = new Queue<HashSet<UnityEngine.Object>>(100);
        public static HashSet<UnityEngine.Object> PoolNewHashSetUnityObject()
        {
            return PoolNew<HashSet<UnityEngine.Object>>(HashSetUnityObjectPool);
        }
        public static void PoolDel(ref HashSet<UnityEngine.Object> needdel)
        {
            if (needdel != null)
            {
                needdel.Clear();
                PoolDel<HashSet<UnityEngine.Object>>(ref needdel, HashSetUnityObjectPool);
            }
        }
        public  static Queue<HashSet<int>> HashSetIntPool = new Queue<HashSet<int>>(100);
        public static HashSet<int> PoolNewHashSetInt()
        {
            return PoolNew<HashSet<int>>(HashSetIntPool);
        }
        public static void PoolDel(ref HashSet<int> needdel)
        {
            if (needdel != null)
            {
                needdel.Clear();
                PoolDel<HashSet<int>>(ref needdel, HashSetIntPool);
            }
        }
        public  static Queue<Dictionary<string, bool>> DicBoolPool = new Queue<Dictionary<string, bool>>(100);
        public static Dictionary<string, bool> PoolNewDicBool()
        {
            return PoolNew<Dictionary<string, bool>>(DicBoolPool);
        }
        public static void PoolDel(ref Dictionary<string, bool> needdel)
        {
            if (needdel != null)
            {
                needdel.Clear();
                PoolDel<Dictionary<string, bool>>(ref needdel, DicBoolPool);
            }
        }
        //public  static Queue<Dictionary<string, Games.TLBB.Render.BaseRender.AnimData>> DicAnimDataPool = new Queue<Dictionary<string, Games.TLBB.Render.BaseRender.AnimData>>(100);
        //public static Dictionary<string, Games.TLBB.Render.BaseRender.AnimData> PoolNewDicAnimData()
        //{
        //    return PoolNew<Dictionary<string, Games.TLBB.Render.BaseRender.AnimData>>(DicAnimDataPool);
        //}
        //
        //public static void PoolDel(ref Dictionary<string, Games.TLBB.Render.BaseRender.AnimData> needdel)
        //{
        //    if (needdel != null)
        //    {
        //        needdel.Clear();
        //        PoolDel<Dictionary<string, Games.TLBB.Render.BaseRender.AnimData>>(ref needdel, DicAnimDataPool);
        //    }
        //}
        public  static Queue<HashSet<string>> HashSetStringPool = new Queue<HashSet<string>>(100);
        public static HashSet<string> PoolNewHashSetString()
        {
            return PoolNew<HashSet<string>>(HashSetStringPool);
        }
        public static void PoolDel(ref HashSet<string> needdel)
        {
            if (needdel != null)
            {
                needdel.Clear();
                PoolDel<HashSet<string>>(ref needdel, HashSetStringPool);
            }
        }
        public  static Queue<List<String>> ListStringPool = new Queue<List<String>>(100);
        public static List<String> PoolNewListString()
        {
            return PoolNew<List<String>>(ListStringPool);
        }
        public static void PoolDel(ref List<String> needdel)
        {
            if (needdel != null)
            {
                needdel.Clear();
                PoolDel<List<String>>(ref needdel, ListStringPool);
            }
        }
        public static Queue<List<AnimationClip>> ListACPool = new Queue<List<AnimationClip>>(100);
        public static List<AnimationClip> PoolNewListAnimationClip()
        {
            return PoolNew<List<AnimationClip>>(ListACPool);
        }
        public static void PoolDel(ref List<AnimationClip> needdel)
        {
            if (needdel != null)
            {
                needdel.Clear();
                PoolDel<List<AnimationClip>>(ref needdel, ListACPool);
            }
        }
        
        public static Queue<HashSet<Animation>> HashSetAnimationgPool = new Queue<HashSet<Animation>>(100);
        public static HashSet<Animation> PoolNewHashSetAnimation()
        {
            return PoolNew<HashSet<Animation>>(HashSetAnimationgPool);
        }
        public static void PoolDel(ref HashSet<Animation> needdel)
        {
            if (needdel != null)
            {
                needdel.Clear();
                PoolDel<HashSet<Animation>>(ref needdel, HashSetAnimationgPool);
            }
        }
        
        public static T SafeRefItem<T>(T[] a, int idx) where T : class
        {
            if(idx>=0 && idx < a.Length)
            {
#if GAMEDEBUG
                if (a[idx] == null)
                {
                    Type t = a.GetType().GetElementType();
                    string tip = string.Format("{0},{1},{2},{3}赶紧找刘震！！！", GameUtil.GetLuaTraceStack(), idx, a.Length, t.Name);
                    MessageBoxProxy.Show(tip, (o) => { }, null, (o) => { MessageBoxProxy.Hide(); }, null, "我找", "我找");
                }
#endif
                return a[idx];
            }
            else
            {
#if GAMEDEBUG
                Type t = a.GetType().GetElementType();
                string tip = string.Format("{0},{1},{2},{3}赶紧找刘震！！！", GameUtil.GetLuaTraceStack(), idx, a.Length, t.Name);
                MessageBoxProxy.Show(tip, (o) => { }, null, (o) => { MessageBoxProxy.Hide(); }, null, "我找", "我找");
#endif
            }
            return null;
        }
        
        public static T SafeRefItem<T>(List<T> a, int idx) where T : class
        {
            if (idx >= 0 && idx < a.Count)
            {
#if GAMEDEBUG
                if (a[idx] == null)
                {
                    T[] aarray = a.ToArray();
                    Type t = aarray.GetType().GetElementType();
                    string tip = string.Format("{0},{1},{2},{3}赶紧找刘震！！！", GameUtil.GetLuaTraceStack(), idx, a.Count, t.Name);
                    MessageBoxProxy.Show(tip, (o) => { }, null, (o) => { MessageBoxProxy.Hide(); }, null, "我找", "我找");
                }
#endif
                return a[idx];
            }
            else
            {
#if GAMEDEBUG
                T[] aarray = a.ToArray();
                Type t = aarray.GetType().GetElementType();
                string tip = string.Format("{0},{1},{2},{3}赶紧找刘震！！！", GameUtil.GetLuaTraceStack(), idx, a.Count, t.Name);
                MessageBoxProxy.Show(tip, (o) => { }, null, (o) => { MessageBoxProxy.Hide(); }, null, "我找", "我找");
#endif
            }
            return null;
        }
        
        public static T SafeValueItem<T>(T[] a, int idx) where T : struct
        {
            if (idx >= 0 && idx < a.Length)
            {
                return a[idx];
            }
            else
            {
#if GAMEDEBUG
                Type t = a.GetType().GetElementType();
                string tip = string.Format("{0},{1},{2},{3}赶紧找刘震！！！", GameUtil.GetLuaTraceStack(), idx, a.Length, t.Name);
                MessageBoxProxy.Show(tip, (o) => { }, null, (o) => { MessageBoxProxy.Hide(); }, null, "我找", "我找");
#endif
            }
            return new T();
        }
        
        public static T SafeValueItem<T>(List<T> a, int idx) where T : struct
        {
            if (idx >= 0 && idx < a.Count)
            {
                return a[idx];
            }
            else
            {
#if GAMEDEBUG
                T[] aarray = a.ToArray();
                Type t = aarray.GetType().GetElementType();
                string tip = string.Format("{0},{1},{2},{3}赶紧找刘震！！！", GameUtil.GetLuaTraceStack(), idx, a.Count, t.Name);
                MessageBoxProxy.Show(tip, (o) => { }, null, (o) => { MessageBoxProxy.Hide(); }, null, "我找", "我找");
#endif
            }
            return new T();
        }

        
        private static Dictionary<int, Queue<object[]>> ObjectArrayPool = new Dictionary<int, Queue<object[]>>();
        
        public static object[] PoolArray(int len)
        {
            Queue<object[]> qo = null;
            if (ObjectArrayPool.TryGetValue(len, out qo) == true)
            {
                if (qo != null)
                {
                    if (qo.Count > 0)
                    {
                        object[] retarray = qo.Dequeue();
                        return retarray;
                    }
                }
            }
            return new object[len];
        }
        
        public static void DelPoolArray(ref object[] oarray)
        {
            if (oarray != null)
            {
                int olen = oarray.Length;
                for (int i = 0; i < olen; i++)
                {
                    oarray[i] = null;
                }

                Queue<object[]> qo = null;
                if (ObjectArrayPool.TryGetValue(olen, out qo) == true)
                {
                    if (qo != null)
                    {
                        if (qo.Count < 10)
                        {
                            qo.Enqueue(oarray);
                        }
                    }
                }
                else
                {
                    Queue<object[]> newqo = new Queue<object[]>();
                    newqo.Enqueue(oarray);
                    ObjectArrayPool[olen] = newqo;
                }
            }
            oarray = null;
        }

        public static void ForceQuit()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidPlatform.NativityManagerActivity.CallStatic("AndroidQuit2");
#else
            Application.Quit();
#endif
        }

//        public static void SafeQuitGame(bool bKeepNotify = false)
//        {
//            LogSystem.Info("SafeQuitGame  come  here!");
//            try
//            {
//                do
//                {
//                    if (GameManager.Instance == null)
//                        break;

//                    ProcedureType type = GameManager.Instance.GetCurrentProcedureType();
//                    if(type == ProcedureType.ChangeScene || type == ProcedureType.Main)
//                    {
//                        IPlatformAdapter ipa = RenderEngine.Scene.SceneManager.PlatformAdapter;
//                        LogSystem.Info("ipa  come  here!");
//                        if (ipa != null)
//                        {
//                            LogSystem.Info("ipa  is  null!");
//                            ipa.SaveConfig();
//                        }
//                        break;
//                    }
//                    else
//                    {
//                        break;
//                    }
//                } while (false);
//            }
//            catch (System.Exception e)
//            {
//                LogSystem.Info(e.ToString());
//#if PLATFORM_TX
//                BuglyAgent._UnregisterExceptionHandler();
//                LogSystem.Info("BuglyAgent  come  end!");
//#endif
//#if UNITY_EDITOR || UNITY_STANDALONE
//                LogSystem.Info("UNITY_EDITOR || UNITY_STANDALONE  come  here!");
//                Application.Quit();
//#elif UNITY_ANDROID
//                LogSystem.Info("UNITY_ANDROID  come  here!");
//                //LogSystem.Info("bKeepNotify   "+bKeepNotify.ToString());
//                if(bKeepNotify == true)
//                {
//                    LogSystem.Info("bKeepNotify  come  here!");
//                    EventManager.SendEvent(DataEvent.ChangeIconAndroid);
//                    AndroidPlatform.NativityManagerActivity.CallStatic("QuiteGame");
//                }
//                else
//                {
//                    LogSystem.Info("Application.Quit  come  here!");
//                    EventManager.SendEvent(DataEvent.ChangeIconAndroid);
//                    Application.Quit();
//                }
//#elif UNITY_IPHONE || UNITY_IOS
//                LogSystem.Info("UNITY_IPHONE || UNITY_IOS  come  here!");
//                //Application.Quit();
//#endif
//                LogSystem.Info("come ending");
//                return;
//            }
//#if PLATFORM_TX
//            LogSystem.Info("BuglyAgent  come  here!");
//            BuglyAgent._UnregisterExceptionHandler();
//            LogSystem.Info("BuglyAgent  come  end!");
//#endif
//#if UNITY_EDITOR || UNITY_STANDALONE
//            LogSystem.Info("UNITY_EDITOR || UNITY_STANDALONE  come  here!");
//            Application.Quit();
//#elif UNITY_ANDROID
//            LogSystem.Info("UNITY_ANDROID  come  here!");
//            //LogSystem.Info("bKeepNotify   "+bKeepNotify.ToString());
//            if(bKeepNotify == true)
//            {
//                LogSystem.Info("bKeepNotify  come  here!");
//                EventManager.SendEvent(DataEvent.ChangeIconAndroid);
//                AndroidPlatform.NativityManagerActivity.CallStatic("QuiteGame");
//            }
//            else
//            {
//                LogSystem.Info("Application.Quit  come  here!");
//                EventManager.SendEvent(DataEvent.ChangeIconAndroid);
//                Application.Quit();
//            }
//#elif UNITY_IPHONE || UNITY_IOS
//            LogSystem.Info("UNITY_IPHONE || UNITY_IOS  come  here!");
//            //Application.Quit();
//#endif
//            LogSystem.Info("come ending");
//        }

        private static uint CalcCrc32(int bytedata, uint dwCrc32)
        {
            return (dwCrc32 >> 8) ^ Crc32Tab[bytedata ^ (dwCrc32 & 0x000000FF)];
        }

        public static UInt64 MaxID
        {
            get
            {
                return 0xFFFFFFFFFFFFFFFFUL;
            }
        }

        public static UInt64 InValidID
        {
            get
            {
                return 0x0000000000000000UL;
            }
        }
#if UNITY_IOS || UNITY_IPHONE && !UNITY_EDITOR
        //[System.Runtime.InteropServices.DllImport("__Internal")]
        //public static extern string WGGetHostByName(string domain);
        //[System.Runtime.InteropServices.DllImport("__Internal")]
        //public static extern void WGGetHostByNameAsync(string domain);//异步获取xcode暂时没接
#endif
        /// <summary>
        /// 是否是有效gbk编码字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        //public static bool IsGBKString(string str)
        //{
        //    char[] strArr = str.ToCharArray();
        //    byte[] netData = CusEncoding.EncodingUtil.CharArrayConvertByteByNet(strArr, 0, strArr.Length);
        //    char[] strArr2 = CusEncoding.EncodingUtil.ByteConvertCharArrayByNet(netData, 0, netData.Length);
        //    string str2 = new string(strArr2);
        //    return str2 == str;
        //}

        const int BytesBufferLength = 8;//
        static byte[] BytesBuffer = new byte[BytesBufferLength];

        /// <summary>
        /// 获取UInt64
        /// </summary>
        /// <param name="high"></param>
        /// <param name="low"></param>
        /// <returns></returns>
        //public static UInt64 EncodeUInt64(int high, int low)
        //{
        //    /*
        //    UInt64 ret = InValidID;

        //    byte[] hB = BitConverter.GetBytes(high);
        //    byte[] lB = BitConverter.GetBytes(low);
        //    byte[] retB = new byte[8];
        //    for (int i = 0; i < 8; i++)
        //    {
        //        if(i < 4)
        //        {
        //            retB[i] = lB[i];
        //        }
        //        else
        //        {
        //            retB[i] = hB[i - 4];
        //        }
        //    }
        //    ret = BitConverter.ToUInt64(retB, 0);
        //    return ret;
        //    */

        //    //return ((ulong)high << 32) | (uint)low;

        //    /**/
        //    byte[] l = SocketStreamAssist.GetBytes(low);
        //    Buffer.BlockCopy(l, 0, BytesBuffer, 0, 4);
            
        //    byte[] h = SocketStreamAssist.GetBytes(high);
        //    Buffer.BlockCopy(h, 0, BytesBuffer, 4, 4);

        //    var result = BitConverter.ToUInt64(BytesBuffer, 0);
        //    return result;
            
        //}

        //public static void DecodeUInt64(UInt64 value, out int high, out int low)
        //{
        //    /*
        //    byte[] vB = BitConverter.GetBytes(value);
        //    */
        //    byte[] vB = SocketStreamAssist.GetBytes(value);
        //    low = BitConverter.ToInt32(vB, 0);
        //    high = BitConverter.ToInt32(vB, 4);
        //}

        //TODO:替换已有
        static RaycastHit[] m_RaycastHitResults = new RaycastHit[32];
        public static int RaycastAllNonAlloc(Ray ray, float maxDistance, int layerMask, out RaycastHit[] results)
        {
            int hitNum = Physics.RaycastNonAlloc(ray, m_RaycastHitResults, maxDistance, layerMask);
            results = m_RaycastHitResults;

            if (hitNum >= m_RaycastHitResults.Length)
            {
                m_RaycastHitResults = new RaycastHit[hitNum+10];
            }

            return hitNum;
        }

        static RaycastHit2D[] m_RaycastHitResults2D = new RaycastHit2D[4];
        public static int GetRayIntersectionAllNonAlloc(Ray ray, float maxDistance, int layerMask, out RaycastHit2D[] results)
        {
            int hitNum = Physics2D.GetRayIntersectionNonAlloc(ray, m_RaycastHitResults2D, maxDistance, layerMask);
            results = m_RaycastHitResults2D;

            if (hitNum >= m_RaycastHitResults2D.Length)
            {
                m_RaycastHitResults2D = new RaycastHit2D[hitNum + 10];
            }

            return hitNum;
        }

        /// <summary>
        /// 获取GUID高32位
        /// TODO：后续唯一性处理
        /// </summary>
        /// <returns></returns>
        public static ulong GetHighGuid()
        {
            return 0x0000000100000000ul;
        }

        public static int GetHighInt()
        {
            return 1;
        }

        /// <summary>
        /// 根据字符串获取crc guid
        /// </summary>
        /// <param name="szName"></param>
        /// <returns></returns>
        public static uint Name2CRC(string szName)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(szName);
            uint dwCrc32 = 0xFFFFFFFF;
            int nSize = bytes.Length;
            for(int i = 0; i < nSize; i++)
            {
                dwCrc32 = CalcCrc32(bytes[i], dwCrc32);
            }
            return dwCrc32;
        }

        public static uint ServerFastCRC(string szName)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(szName);
            uint dwCrc32 = 0xFFFFFFFF;
            int nSize = bytes.Length;
            for (int i = 0; i < nSize; i++)
            {
                dwCrc32 = dwCrc32 * 33 + bytes[i];
            }
            return dwCrc32;
        }


        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="bflag">默认返回秒</param>
        /// <returns></returns>
        public static Int32 GetTimeStamp(bool bflag = true)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            Int32 ret;
            if (bflag)
                ret = Convert.ToInt32(ts.TotalSeconds);
            else
                ret = Convert.ToInt32(ts.TotalMilliseconds);
            return ret;
        }



        private static readonly UInt32[] Crc32Tab = new UInt32[] {
            0x00000000, 0x77073096, 0xee0e612c, 0x990951ba,
            0x076dc419, 0x706af48f, 0xe963a535, 0x9e6495a3,
            0x0edb8832, 0x79dcb8a4, 0xe0d5e91e, 0x97d2d988,
            0x09b64c2b, 0x7eb17cbd, 0xe7b82d07, 0x90bf1d91,
            0x1db71064, 0x6ab020f2, 0xf3b97148, 0x84be41de,
            0x1adad47d, 0x6ddde4eb, 0xf4d4b551, 0x83d385c7,
            0x136c9856, 0x646ba8c0, 0xfd62f97a, 0x8a65c9ec,
            0x14015c4f, 0x63066cd9, 0xfa0f3d63, 0x8d080df5,
            0x3b6e20c8, 0x4c69105e, 0xd56041e4, 0xa2677172,
            0x3c03e4d1, 0x4b04d447, 0xd20d85fd, 0xa50ab56b,
            0x35b5a8fa, 0x42b2986c, 0xdbbbc9d6, 0xacbcf940,
            0x32d86ce3, 0x45df5c75, 0xdcd60dcf, 0xabd13d59,
            0x26d930ac, 0x51de003a, 0xc8d75180, 0xbfd06116,
            0x21b4f4b5, 0x56b3c423, 0xcfba9599, 0xb8bda50f,
            0x2802b89e, 0x5f058808, 0xc60cd9b2, 0xb10be924,
            0x2f6f7c87, 0x58684c11, 0xc1611dab, 0xb6662d3d,
            0x76dc4190, 0x01db7106, 0x98d220bc, 0xefd5102a,
            0x71b18589, 0x06b6b51f, 0x9fbfe4a5, 0xe8b8d433,
            0x7807c9a2, 0x0f00f934, 0x9609a88e, 0xe10e9818,
            0x7f6a0dbb, 0x086d3d2d, 0x91646c97, 0xe6635c01,
            0x6b6b51f4, 0x1c6c6162, 0x856530d8, 0xf262004e,
            0x6c0695ed, 0x1b01a57b, 0x8208f4c1, 0xf50fc457,
            0x65b0d9c6, 0x12b7e950, 0x8bbeb8ea, 0xfcb9887c,
            0x62dd1ddf, 0x15da2d49, 0x8cd37cf3, 0xfbd44c65,
            0x4db26158, 0x3ab551ce, 0xa3bc0074, 0xd4bb30e2,
            0x4adfa541, 0x3dd895d7, 0xa4d1c46d, 0xd3d6f4fb,
            0x4369e96a, 0x346ed9fc, 0xad678846, 0xda60b8d0,
            0x44042d73, 0x33031de5, 0xaa0a4c5f, 0xdd0d7cc9,
            0x5005713c, 0x270241aa, 0xbe0b1010, 0xc90c2086,
            0x5768b525, 0x206f85b3, 0xb966d409, 0xce61e49f,
            0x5edef90e, 0x29d9c998, 0xb0d09822, 0xc7d7a8b4,
            0x59b33d17, 0x2eb40d81, 0xb7bd5c3b, 0xc0ba6cad,
            0xedb88320, 0x9abfb3b6, 0x03b6e20c, 0x74b1d29a,
            0xead54739, 0x9dd277af, 0x04db2615, 0x73dc1683,
            0xe3630b12, 0x94643b84, 0x0d6d6a3e, 0x7a6a5aa8,
            0xe40ecf0b, 0x9309ff9d, 0x0a00ae27, 0x7d079eb1,
            0xf00f9344, 0x8708a3d2, 0x1e01f268, 0x6906c2fe,
            0xf762575d, 0x806567cb, 0x196c3671, 0x6e6b06e7,
            0xfed41b76, 0x89d32be0, 0x10da7a5a, 0x67dd4acc,
            0xf9b9df6f, 0x8ebeeff9, 0x17b7be43, 0x60b08ed5,
            0xd6d6a3e8, 0xa1d1937e, 0x38d8c2c4, 0x4fdff252,
            0xd1bb67f1, 0xa6bc5767, 0x3fb506dd, 0x48b2364b,
            0xd80d2bda, 0xaf0a1b4c, 0x36034af6, 0x41047a60,
            0xdf60efc3, 0xa867df55, 0x316e8eef, 0x4669be79,
            0xcb61b38c, 0xbc66831a, 0x256fd2a0, 0x5268e236,
            0xcc0c7795, 0xbb0b4703, 0x220216b9, 0x5505262f,
            0xc5ba3bbe, 0xb2bd0b28, 0x2bb45a92, 0x5cb36a04,
            0xc2d7ffa7, 0xb5d0cf31, 0x2cd99e8b, 0x5bdeae1d,
            0x9b64c2b0, 0xec63f226, 0x756aa39c, 0x026d930a,
            0x9c0906a9, 0xeb0e363f, 0x72076785, 0x05005713,
            0x95bf4a82, 0xe2b87a14, 0x7bb12bae, 0x0cb61b38,
            0x92d28e9b, 0xe5d5be0d, 0x7cdcefb7, 0x0bdbdf21,
            0x86d3d2d4, 0xf1d4e242, 0x68ddb3f8, 0x1fda836e,
            0x81be16cd, 0xf6b9265b, 0x6fb077e1, 0x18b74777,
            0x88085ae6, 0xff0f6a70, 0x66063bca, 0x11010b5c,
            0x8f659eff, 0xf862ae69, 0x616bffd3, 0x166ccf45,
            0xa00ae278, 0xd70dd2ee, 0x4e048354, 0x3903b3c2,
            0xa7672661, 0xd06016f7, 0x4969474d, 0x3e6e77db,
            0xaed16a4a, 0xd9d65adc, 0x40df0b66, 0x37d83bf0,
            0xa9bcae53, 0xdebb9ec5, 0x47b2cf7f, 0x30b5ffe9,
            0xbdbdf21c, 0xcabac28a, 0x53b39330, 0x24b4a3a6,
            0xbad03605, 0xcdd70693, 0x54de5729, 0x23d967bf,
            0xb3667a2e, 0xc4614ab8, 0x5d681b02, 0x2a6f2b94,
            0xb40bbe37, 0xc30c8ea1, 0x5a05df1b, 0x2d02ef8d
        };

        /// <summary>
        /// 把\\转换为\ 把\0转换为0
        /// </summary>
        /// <param name="pIn"></param>
        /// <param name="pOut"></param>
        public static int Str2Bin(byte[] pIn, ref byte[] pOut,int nBeginPos , int nLength)
        {
            byte BACK_SLASH_BYTE = Convert.ToByte('\\');
            byte ZERO_BYTE = Convert.ToByte('0');

            //List< byte> pOutList = new List<byte>();
            int pInLen = pIn.Length;
            if(pInLen <= 0)
            {
                pOut = null;
            }

            int outArrIndex = 0;
            for(int i = nBeginPos; i < (nLength + nBeginPos - 1);)
            {
                if(pIn[i] == BACK_SLASH_BYTE && pIn[i+1] == ZERO_BYTE)
                {
                    pOut[outArrIndex++] = 0;
                    //pOutList.Add(0);
                    i += 2;
                    continue;
                }
                else if(pIn[i] == BACK_SLASH_BYTE && pIn[i+1] == BACK_SLASH_BYTE)
                {
                    //pOutList.Add(Convert.ToByte('\\'));
                    pOut[outArrIndex++] = BACK_SLASH_BYTE;

                    i += 2;
                    continue;
                }
                else if(pIn[i] == 0)
                {
                    break;
                }
                pOut[outArrIndex++] = pIn[i];
                //pOutList.Add(pIn[i]);
                i++;
            }
            pOut[outArrIndex++] = pIn[pInLen - 1];

            return outArrIndex;
         //   pOutList.Add(pIn[pInLen - 1]);
           // pOut = pOutList.ToArray();
        }

        /// <summary>
        /// 判断charmodel表的box合法
        /// TODO：后续唯一性处理
        /// </summary>
        /// <returns></returns>
        //public static bool CheckBoxInvalid(CharModelExTableVO vo)
        //{
        //    if (vo != null)
        //    {
        //        if (vo.BoxCenterX <= 0f && vo.BoxCenterY <= 0f && vo.BoxCenterY <= 0f
        //            && vo.BoxSizeX <= 0f && vo.BoxSizeY <= 0f && vo.BoxSizeZ <= 0f)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        public static string ToMD5(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            try
            {
#if UNITY_WP8
				return CryptoNet.Md5.ComputeHash(Encoding.UTF8.GetBytes(str)).ToLower();
#else
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                return System.BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
#endif
            }
            catch (System.Exception e)
            {
                LogSystem.Error(e.ToString());
                return null;
            }
        }

//         public static Dictionary<string, string> ReadDictionary(string str)
//         {
//             Dictionary<string, string> dic = new Dictionary<string, string>();
//             string[] lines = str.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
//             for (int i = 0; i < lines.Length; i++)
//             {
//                 string line = lines[i].Trim();
//                 if (string.IsNullOrEmpty(line) || line.StartsWith("#") || line.StartsWith("//"))
//                 {
//                     continue;
//                 }
// 
//                 string[] splites = line.Split(new char[] { '=' }, 2);
//                 if (2 == splites.Length)
//                 {
//                     try
//                     {
//                         if (!dic.ContainsKey(splites[0].Trim()))
//                             dic.Add(splites[0].Trim(), splites[1].Trim());
//                     }
//                     catch (System.Exception ex)
//                     {
//                         LogSystem.Error("The key '" + splites[0].Trim() + "' " + ex.ToString());
//                     }
//                 }
//                 else
//                 {
//                     LogSystem.Error("Parse Error: " + line);
//                 }
//             }
// 
//             return dic;
//         }

//         public static string ParseDictionary(Dictionary<string, string> dic)
//         {
//             string str = "";
//             foreach (string key in dic.Keys)
//             {
//                 str += key + "=" + dic[key] + "\n";
//             }
//             return str;
//         }

        public static void DeleteFolder(string path, bool recursive = true)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, recursive);
            }
            else
            {
                //LogSystem.Warn("DeleteFolder Warning: The folder is not exist: " + path);
            }
        }

        // 获取MD5
        public static string GetFileMD5(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            try
            {
                FileStream get_file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                //LogSystem.Info("GetFileMD5 Open: {0}", get_file.Name);
#if UNITY_WP8
				byte[] buf = new byte[64*1024]; // 64k buffer;
				int siz = 1;
				CryptoNet.Md5 md5 = CryptoNet.Md5.Create();
				get_file.Position = 0;
				while(siz>0)
				{
					siz = get_file.Read(buf, 0, 64*1024); 
					md5.Update(buf, 0, siz);
				}
				string result = md5.Result().ToLower();
#else
                System.Security.Cryptography.MD5CryptoServiceProvider get_md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hash_byte = get_md5.ComputeHash(get_file);
                string result = System.BitConverter.ToString(hash_byte).Replace("-", "");
#endif
                //LogSystem.Info("GetFileMD5 Close: {0}", get_file.Name);
                get_file.Dispose();
                return result;
            }
            catch (System.Exception e)
            {
                LogSystem.Error(e.ToString());
                return null;
            }
        }

        public static long GetFileSize(string path)
        {
            long ret = 0;
            if (!File.Exists(path))
            {
                return ret;
            }
            try
            {
                FileStream get_file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                LogSystem.Info("GetFileSize Open: {0}", get_file.Name);
                ret = get_file.Length;
                LogSystem.Info("GetFileSize Close: {0}", get_file.Name);
                get_file.Close();
                return ret;
            }
            catch (System.Exception e)
            {
                LogSystem.Error(e.ToString());
                return ret;
            }
        }
        public static bool CheckTargetPath(string targetPath)
        {
            try
            {

            if (Directory.Exists(targetPath))
            {
                return true;
            }

            targetPath = targetPath.Replace('\\', '/');

            int dotPos = targetPath.LastIndexOf('.');
            int lastPathPos = targetPath.LastIndexOf('/');

            if (dotPos > 0 && lastPathPos < dotPos)
            {
                targetPath = targetPath.Substring(0, lastPathPos);
            }


            string[] subPath = targetPath.Split('/');
            string curCheckPath = "";
            int subContentSize = subPath.Length;
            for (int i = 0; i < subContentSize; i++)
            {
                curCheckPath += subPath[i] + '/';
                if (!Directory.Exists(curCheckPath))
                {
                    Directory.CreateDirectory(curCheckPath);
                }
            }

            return true;

            }
            catch
            {
                return false;
            }

        }
        // 获取大小的格式化字符串
        public static string GetSizeFormateStr(long size)
        {
            if (size < 1024)
            {
                return size + "B";
            }
            else if (size < 1024 * 1024)
            {
                return ((float)size / 1024f).ToString("0.00") + "KB";
            }
            else
            {
                return ((float)size / (1024f * 1024f)).ToString("0.00") + "M";
            }
        }
        // 获取大小的整数格式化字符串
        public static string GetSizeIntegerFormateStr(long size)
        {
            if (size < 1024)
            {
                return size + "B";
            }
            else if (size < 1024 * 1024)
            {
                return ((float)size / 1024f).ToString("0") + "KB";
            }
            else
            {
                return ((float)size / (1024f * 1024f)).ToString("0") + "M";
            }
        }
        public static bool IsNetworkAvailable
        {
            get
            {
#if UNITY_EDITOR
                // 编辑器不做判定
                return true;
// 没必要这样判断了
//#elif UNITY_STANDALONE
//                try
//                {
//                    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
//                    foreach (NetworkInterface nic in nics)
//                    {
//                        if ((nic.NetworkInterfaceType != NetworkInterfaceType.Loopback
//                            && nic.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
//                            && nic.OperationalStatus == OperationalStatus.Up)
//                        {
//                            return true;
//                        }
//                    }

//                    return false;
//                }
//                catch (System.Exception e)
//                {
//                    LogSystem.Error(e.ToString());
//                    return false;
//                }
#elif UNITY_IPHONE || UNITY_ANDROID || UNITY_STANDALONE
				return Application.internetReachability != NetworkReachability.NotReachable;
#else
                return false;
#endif
            }
        }
        // 是否是自身网络
        public static bool IsSelfNetwork
        {
            get
            {
#if UNITY_EDITOR
                return false;
#elif UNITY_IPHONE || UNITY_ANDROID || UNITY_STANDALONE
				return Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork;
#else
                return false;
#endif
            }
        }

        /// Copies the src files to dest folder.
        public static void CopyFilesToFolder(string srcFolder, string destFolder, string extension, bool samePath = false)
        {
            // create folder if not exist.
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            // copy files
            string[] files = null;
            if (extension.Equals("*"))
            {
                files = Directory.GetFiles(srcFolder);
            }
            else
            {
                files = Directory.GetFiles(srcFolder, "*." + extension);
            }

            foreach (string file in files)
            {
                if (string.IsNullOrEmpty(Path.GetExtension(file)))
                {
                    File.Copy(file, destFolder + "/" + Path.GetFileName(file), true);
                }
                else
                {
                    File.Copy(file, destFolder + "/" + Path.GetFileNameWithoutExtension(file) + Path.GetExtension(file), true);
                }
            }

            // travel the sub-folder
            string[] folders = Directory.GetDirectories(srcFolder);
            foreach (string folder in folders)
            {
                if (samePath)
                {
                    CopyFilesToFolder(folder, destFolder + "/" + Path.GetFileName(folder), extension, samePath);
                }
                else
                {
                    CopyFilesToFolder(folder, destFolder, extension, samePath);
                }
            }
        }

        private static Regex EmptyStartReg = new Regex(@"^\s*");
        private static Regex ExpEndReg = new Regex(@"\)\s*;{0,}\s*$");

        private static List<string> LogExpList = new List<string>() { "print(", "printe(", "printw(" };

        /// <summary>
        /// 注释所有打印
        /// </summary>
        /// <param name="bytes">Utf8 bytes</param>
        /// <returns></returns>
        public static byte[] CommentLogs(byte[] bytes)
        {
            byte[] newBytes = null;
            string[] lines = null;
            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            string content = utf8WithoutBom.GetString(bytes);
            string newLineStr = Environment.NewLine;
            //char[] lineArr = newLineStr.ToCharArray();
            lines = content.Split(new string[] { newLineStr }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                Match match = EmptyStartReg.Match(line);
                string tmpLine = line;
                if (match.Success)
                {
                    string matchValue = match.Value;
                    tmpLine = line.Substring(matchValue.Length);
                    //检测结尾
                    //TODO:需要更严格的匹配方式 检测语句是否结束
                    Match expEndMatch = ExpEndReg.Match(tmpLine);
                    if (expEndMatch.Success)
                    {
                        for (int j = 0; j < LogExpList.Count; j++)
                        {
                            if (tmpLine.StartsWith(LogExpList[j]))
                            {
                                line = matchValue + "--" + tmpLine;
                                break;
                            }
                        }
                    }
                }
                lines[i] = line;
            }

            content = "";
            for (int i = 0; i < lines.Length; i++)
            {
                content = content + lines[i] + Environment.NewLine;
            }

            newBytes = utf8WithoutBom.GetBytes(content);

            return newBytes;
        }

        //public static byte[] Encode(string fileName)
        //{
        //    if (!File.Exists(fileName))
        //        return null;
        //    byte[] content = CusEncoding.EncodingUtil.FileByteToLocal(File.ReadAllBytes(fileName));

        //    //注释lua中的print等打印代码
        //    //content = CommentLogs(content);

        //    int len = content.Length;
        //    for(int i=0;i<len;++i)
        //    {
        //        byte check = (byte)((len*i)%byte.MaxValue);
        //        content[i] ^= check;
        //    }
        //    return content;
        //    //return System.Convert.ToBase64String(content);
        //}

        //public static string Decode(string fileName)
        //{
        //    if (!File.Exists(fileName))
        //        return null;
        //    StreamReader sr = File.OpenText(fileName);
        //    String data = sr.ReadToEnd();
        //    sr.Close();
        //    sr.Dispose();
        //    byte[] content = System.Convert.FromBase64String(data);
        //    return new string(System.Text.Encoding.UTF8.GetChars(content));
        //}

        //public static string GetLuaTraceStack()
        //{
        //    if (LuaScriptMgr.Instance == null)
        //    {
        //        return "none";
        //    }

        //    string stack = LuaScriptMgr.Instance.Invoke<string,string>("traceback", "");
        //    return stack;
        //}

        //public static int GetLuaMemCount()
        //{
        //    if (LuaScriptMgr.Instance == null)
        //    {
        //        return 0;
        //    }

        //    int count = LuaScriptMgr.Instance.Invoke<int>("LuaMemCount");
        //    return count;
        //}

        //public static void ForceQuitGame(string msg, string btnName1="确定", string btnName2="取消")
        //{
        //    // 弹出对话框，关闭
        //    MessageBoxProxy.Show(msg, (param) => Games.TLBB.Util.GameUtil.SafeQuitGame(), null, null, null, btnName1, btnName2);
        //}

        //防劫持url转换
        /**
        public static string GetHttpDnsIP(string strUrl)
        {
#if UNITY_IOS || UNITY_IPHONE && !UNITY_EDITOR
            //string ips = WGGetHostByName(strUrl);
            //string[] sArray=ips.Split(new char[] {';'});
            //if (sArray != null && sArray.Length > 1)
            //{
            // if (!sArray[1].Equals("0"))
            // {
            ////使用建议：当ipv6地址存在时，优先使用ipv6地址
            ////TODO 使用ipv6地址进行URL连接时，注意格式，需加方框号[ ]进行处理，例如：http://[64:ff9b::b6fe:7475]/
            //    return "["+sArray[1]+"]";
            // }
            // else if (!sArray[0].Equals("0"))
            // {
            ////使用ipv4地址进行连接
            //    return sArray[0];
            // }
            //else
            //{
            ////异常情况返回为0,0，建议重试一次
            //    return "";
            // }
            // }else{
            //   return strUrl;
            // }
            return strUrl;
#elif UNITY_ANDROID && !UNITY_EDITOR
                    string strIp = string.Empty;
                     //解析得到IP配置集合
                    strIp = AndroidPlatform.DnsActivityClass.Call<string>("getAddrByName", strUrl);
                    if (strIp != null)
                    {
                         //取第一个
                        string[] strIps = strIp.Split(';');
                        strIp = strIps[0];
                    }
                    return strIp;

#else
            return strUrl;
#endif
        }
        //注意只有域名才能调用该方法，不是域名不可调用
        public static string GetIpDress(string dress)
        {
            string yuming = "";
            string duankou = "";
            //获取域名和端口用于dnssdk域名转化 
            string[] strs = dress.Split(new char[] { ':' });
            if (strs.Length > 1)
            {
                yuming = strs[0];
                duankou = strs[1];
            }
            else
            {
                yuming = dress;
            }
            string ipstring = "";
            ipstring = GameUtil.GetHttpDnsIP(yuming);//调用sdk获取转后后的IP地址
            if (ipstring!="")
            {
                if (duankou != "")
                {
                    ipstring = ipstring + ":" + duankou;//ip+端口号
                }
                return ipstring;
            }
            else
            {
                //sdk没有返回，直接返回域名
                return dress;
            }
        }*/

        private static bool? s_ReportExceptionFlag = null;
        public static bool ReportExceptionFlag
        {
            get
            {
                //newDownLoad阶段直接开启上报bugly
                //if (GameManager.Instance != null)
                //{
                //    ProcedureType type = GameManager.Instance.GetCurrentProcedureType();
                //    if (type == ProcedureType.NewDownload)
                //    {
                //        return true;
                //    }
                //}


                if (!s_ReportExceptionFlag.HasValue)
                {
                    string key = "OtherReportException";
#if UNITY_EDITOR
#elif UNITY_IPHONE || UNITY_IOS
                    key = "iOSReportException";
#elif UNITY_ANDROID
                    key = "AndroidReportException";
#endif
                    int value = 0;
                    //if (!SystemCFG.Instance.GetInt("Bugly", key, out value))
                    //{
                    //    value = 0;
                    //}

                    s_ReportExceptionFlag = value > 0;
                }

                return s_ReportExceptionFlag.Value;
            }
        }

        //        private static bool? s_ReportExceptionWithLuaStackFlag = null;
        //        public static bool ReportExceptionWithLuaStackFlag
        //        {
        //            get
        //            {
        //                if (!s_ReportExceptionWithLuaStackFlag.HasValue)
        //                {
        //                    int value = 0;
        //                    if (!SystemCFG.Instance.GetInt("Bugly", "ReportExceptionWithLuaStack", out value))
        //                    {
        //                        value = 0;
        //                    }

        //                    s_ReportExceptionWithLuaStackFlag = value > 0;
        //                }

        //                return s_ReportExceptionWithLuaStackFlag.Value;
        //            }
        //        }

        static int sizeMB = 1024 * 1024;
        static System.Exception g_DefaultException = new System.Exception("DefaultException");

        public static void LogAndReportException(string message)
        {
            LogAndReportException(null, message);
        }

        public static void ReportMemoryInfo()
        {
#if !UNITY_EDITOR && UNITY_ANDROID && PLATFORM_TX
            int totalUsed = (int)(UnityEngine.Profiling.Profiler.GetTotalReservedMemory() / sizeMB);
            int validMem = AndroidPlatform.NativityManagerActivity.CallStatic<int>("GetValidMemory");
            int thresholdMem = AndroidPlatform.NativityManagerActivity.CallStatic<int>("GetThresholdMemory");
            int totalMem = AndroidPlatform.NativityManagerActivity.CallStatic<int>("GetTotalMemory");

            string memInfo = string.Format("totalUsed:{0}, validMem:{1}, totalMem:{2}, thresholdMem:{3}", totalUsed, validMem, totalMem, thresholdMem);
            EventManager.SendEvent(DataEvent.BuglyLog, memInfo, Msdk.eBuglyLogLevel.eBuglyLogLevel_E);
#endif

        }

        static bool IsWaiFa = false;
        public static bool IsWaiFaApk()
        {
            return IsWaiFa;
        }

        public static void SetWaiFaApk(bool iswf)
        {
            IsWaiFa = iswf;
            LogSystem.Info("设置外发版本 {0}", IsWaiFa);
        }

        static bool? _IsWaiFaEnable;
        public static bool IsWaiFaEnable()//是否外发屏蔽 true 屏蔽
        {
            if (!IsWaiFaApk())
            {
                return false;
            }

#if !UNITY_EDITOR && UNITY_ANDROID && PLATFORM_TX
            if (!_IsWaiFaEnable.HasValue)
            {
                int value = 0;
                if (!SystemCFG.Instance.GetInt("Global", "WaiFaEnable", out value))
                {
                    value = 0;
                }

                _IsWaiFaEnable = value > 0;
            }

            return _IsWaiFaEnable.Value;
#else
            return false;
#endif
        }

        public static void LogAndReportException(System.Exception exception, string message)
        {
            bool isDefault = false;
            if (exception == null)
            {
                exception = g_DefaultException;
                isDefault = true;
            }

#if GAMEDEBUG
            LogSystem.Error(string.Format("{0}\n{1}\n{2}", exception, message, ReportExceptionFlag));
#endif
            if (ReportExceptionFlag)
            {
                string errorMessage = null;
                //if (isDefault)
                //{
                //    errorMessage = UniverseX.UniverseXTools.StackTrace();
                //}
                //else
                //{
                //    errorMessage = string.Format("{0}:{1}", exception.Message, exception.StackTrace);
                //}

                //Lua.LuaLogSystem.Error(errorMessage);
#if PLATFORM_TX
                EventManager.SendEvent(DataEvent.BuglyLog, errorMessage, Msdk.eBuglyLogLevel.eBuglyLogLevel_E);
                if (ReportExceptionWithLuaStackFlag)
                {
                    message += " [LuaStack]" + GetLuaTraceStack();
                }

                BuglyAgent.ReportException(exception, message);
#if GAMEDEBUG
                LogSystem.Error(string.Format("PLATFORM_TX{0}\n{1}", exception, message));
#endif

                ReportMemoryInfo();

#endif
            }
        }

        //public static Newtonsoft.Json.JsonSerializer g_JsonSerializer = new Newtonsoft.Json.JsonSerializer();

        //public static T JsonDeserialize<T>(byte[] buffer, int index, int count)
        //{
        //    try
        //    {
        //        using (MemoryStream ms = new MemoryStream(buffer, index, count))
        //        using (StreamReader sr = new StreamReader(ms))
        //        return (T)g_JsonSerializer.Deserialize(sr, typeof(T));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogAndReportException(e, "JsonDeserialize<T>(byte[] buffer, int index, int count)");
        //    }

        //    return default(T);
        //}

        //public static void JsonSerialize(string path, object value)
        //{
        //    using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
        //    using (StreamWriter ss = new StreamWriter(stream))
        //    using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(ss))
        //    {
        //        g_JsonSerializer.Serialize(writer, value);
        //    }
        //}


        #region=====封装值类型转换=====
        /// <summary>
        /// 此接口只适用于lua中传递到c#中的参数解析
        /// lua中传递过来的int参数是double的
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetConvetedInt(object obj)
        {
            try
            {
                int num = (int)Convert.ToDouble(obj);
                return num;
            }catch(System.Exception e)
            {
                return -1;
            }
        }
        public static short GetConvetedShort(object obj)
        {
            try
            {
                short num = (short)Convert.ToDouble(obj);
                return num;
            }
            catch (System.Exception e)
            {
                return -1;
            }
        }
        public static ulong GetConvetedUlong(object obj)
        {
            try
            {
                ulong num = (ulong)Convert.ToUInt64((string)obj);
                return num;
            }
            catch (System.Exception e)
            {
                return 0;
            }
        }

        public static byte GetConvertedByte(object obj)
        {
            try
            {
                byte num = (byte) Convert.ToByte(obj);
                return num;
            }
            catch (System.Exception e)
            {
                return 0;
            }
        }
        public static bool GetConvetedBool(object obj)
        {
            try
            {
                bool b = (bool)Convert.ToBoolean(obj);
                return b;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }
        #endregion=====封装值类型转换=====




        #region 合服玩家名字调整
        private static int MAX_NAME_LENGTH = 12;
        ////合服重名的名字截取
        //public static string ConvertName(string name)
        //{
        //    if (name == null) return "";
        //    if (!name.Contains("*")) return name;//合服的重名处理的特殊标识符*号

        //    int charLen = SocketStreamAssist.GetStringBytesLen(name, false);
        //    if (charLen > MAX_NAME_LENGTH)
        //    {
        //        char[] nameChars = name.ToCharArray();
        //        char[] resultChars = null;
        //        int lastIndex = GetLastIndex(nameChars);
        //        if (lastIndex < 2) return "";
        //        char c = nameChars[lastIndex];
        //        if (c > 127)//c是汉字 的时候切割一个；其他情况切割两个字符
        //        {
        //            resultChars = new char[lastIndex];
        //            for (int i = 0; i < lastIndex; i++)
        //            {
        //                resultChars[i] = nameChars[i];
        //            }
        //        }
        //        else
        //        {
        //            resultChars = new char[lastIndex - 1];
        //            for (int i = 0; i < lastIndex - 1; i++)
        //            {
        //                resultChars[i] = nameChars[i];
        //            }
        //        }
        //        name = new string(resultChars);
        //        name = name + "..";
        //    }

        //    return name;
        //}
        //获取名字超长字符串中符合最后一个字符的索引
        private static int GetLastIndex(char[] c)
        {
            if (c == null) return -1;
            int len = 0;
            int index = -1;
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] <= 127)
                {
                    len += 1;
                }
                else
                {
                    len += 2;
                }
                if (len >= MAX_NAME_LENGTH)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

#endregion


        public static string MakeUrlUnique(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return url;
            }

            string r = Guid.NewGuid().ToString("N");
            if (url.IndexOf('?') >= 0)
            {
                url = string.Format("{0}&unique={1}", url, r);
            }
            else
            {
                url = string.Format("{0}?unique={1}", url, r);
            }
            return url;
        }

        //获取动作名称
        //public static string GetActionStr(int id)
        //{
        //    var vo = TableManager.GetTableLine<ActionStrVO>(576, id);
        //    if (vo == null)
        //    {
        //        return string.Empty;
        //    }
        //    return vo.ActionName;

        //}
    }
}
