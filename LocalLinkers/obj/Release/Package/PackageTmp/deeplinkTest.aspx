<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deeplinkTest.aspx.cs" Inherits="LocalLinkers.deeplinkTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title></title>

    <script src="/js/jquery-1.10.2.js"></script>
    <%--  <script src="/js/jqueryMobile.js"></script>--%>
    <script src="/js/deeplink.js"></script>
<script src="/js/visibly.js"></script>
      <script type="text/javascript">
         <!--

    if(navigator.userAgent.match(/iPhone/i)){
        window.location = '​browze​://';
    }


    else if(navigator.userAgent.match(/Android/i)){
        window.location = 'intent://#Intent;scheme=browze;package=com.browze;end;';
    }



    else
    {

        window.location = 'http://​browze.​co/';

    }

          
           
    //-->
      </script>
    <%--<script src="/js/browser-deeplink.js"></script>--%>

    <%--<script>

        //deeplink.setup({
        //    iOS: {
        //        appName: "locallinkers",
        //        appId: "1098179119",
        //    },
        //    android: {
        //        appId: "com.hbs.hashbrownsys.locallinkers"
        //    }
        //});
        //function clickHandler(uri) {
        //    deeplink.open(uri);
        //    return false;
        //}
        //window.onload = function () {
        //    deeplink.open("locallinkers://");
        //}
        //$(function () {
        //    if (/Android|iPhone|iPad|iPod/i.test(navigator.userAgent)) {
        //        window.location="locallinkers://"
        //        //$("#aClick").trigger("click");
        //        //document.location.href = 'locallinkers://';
        //        //setTimeout("window.location = 'http://hastrk.com/serve?action=click&publisher_id=1&site_id=2';", 1000);
        //        setTimeout(ShowDownloadAppLink, 1000);
        //    }

        //})
        //function ShowDownloadAppLink()
        //{
        //    $("#divDownloadAppLink").show();
        //}



        function launchIframeApproach(url, alt) {
            var iframe = document.createElement("iframe");
            iframe.style.border = "none";
            iframe.style.width = "1px";
            iframe.style.height = "1px";
            iframe.onload = function() {
                document.location = alt;
            }
            document.body.appendChild(iframe);
        }

        function launchWebkitApproach(url, alt) {
            document.location = url;
            timer = setTimeout(function () {
                document.location = alt;
            }, 2500);
        }

        function launchAndroidApp(url) {
            var androidAppStore = "https://play.google.com/store/apps/details?id=com.hbs.hashbrownsys.locallinkers";
            //var androidAppStore = "https://play.google.com/store/apps/details?id=com.browze";
            //var androidAppStore = "http://market.android.com/details?id=MYAPP-PACKAGE-NAME";
            var g_intent = "scheme=locallinkers;package=com.hbs.hashbrownsys.locallinkers;end"; //see notes below

            if(navigator.userAgent.match(/Chrome/)) {
                //var intent = url.replace('MYAPP', 'intent') + '#Intent;' + g_intent; //see notes below
                var intent = url.replace('browze', 'intent') + '#Intent;' + g_intent; //see notes below
                document.location = intent;
            } 
            else if (navigator.userAgent.match(/Firefox/)) {
                launchWebkitApproach(url, androidAppStore);
                setTimeout(function () {
                    launchIframeApproach(url, androidAppStore);
                }, 1500);
            }
            else {
                launchIframeApproach(url, androidAppStore);
            }
        }

        function launchiOSApp(url) {
            //locallinkers var appleAppStoreLink = 'https://itunes.apple.com/us/app/local-linkers/id1098179119?ls=1&mt=8';
            var appleAppStoreLink = 'https://itunes.apple.com/in/app/browze-app/id1049738179?mt=8';

            //var appleAppStoreLink = 'https://itunes.apple.com/us/app/local-linkers/id1098179119';
            var now = new Date().valueOf();
            setTimeout(function () {
                if (new Date().valueOf() - now > 500) return;
                window.location = appleAppStoreLink;
            }, 100);
            window.location = url;

            //window.location = url;
            //setTimeout(function () {
            //    window.location = appleAppStoreLink;
            //}, 250);
        }




        $(function () {

            $('#my-link').click(function ()
            {
                var iOS = /(iPad|iPhone|iPod)/g.test(navigator.userAgent);
                if (!iOS) {
                    launchAndroidApp('browze://');
                }
                else {
                    launchiOSApp('oncanoe://');
                    //setTimeout(OnApp, 250);
                }
            });
          //  setTimeout(OnApp, 2000);

        });
        //function OnApp()
        //{
        //    $('#my-link').trigger("tap");
        //}

        //$(function () {
        //    if (/Android|iPhone|iPad|iPod/i.test(navigator.userAgent)) {
        //        $("#divOpenLocallinkers").show();

        //        //$("#aClick").trigger("click");
        //        //document.location.href = 'locallinkers://';
        //        //setTimeout("window.location = 'http://hastrk.com/serve?action=click&publisher_id=1&site_id=2';", 1000);

        //    }

        //})
        //function GoToAppStore() {
        //    var url;
        //    if (/Android|iPhone|iPad|iPod/i.test(navigator.userAgent)) {
        //        url = "https://play.google.com/store/apps/details?id=com.hbs.hashbrownsys.locallinkers";
        //    }
        //    else if (/iPhone|iPad|iPod/i.test(navigator.userAgent))
        //    {
        //        url = "https://itunes.apple.com/us/app/local-linkers/id1098179119?ls=1&mt=8";
        //    }
        //    setTimeout("window.location = '"+url+"';", 1000);
        //}
        //(function () {
        //    var app = {
        //        launchApp: function () {
        //            window.location.replace("locallinkers://");
        //            this.timer = setTimeout(this.openWebApp, 1000);
        //        },

        //        openWebApp: function () {
        //            window.location.replace("https://play.google.com/store/apps/details?id=com.hbs.hashbrownsys.locallinkers");
        //        }
        //    };

        //    app.launchApp();
        //})();
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
         <div>
            <a id="my-link" style="cursor:pointer;">click here</a>
        </div>
       <%-- <a href="https://play.google.com/store/apps/details?id=com.hbs.hashbrownsys.locallinkers"
               data-app="locallinkers://"
                >Start Application</a>--%>
        <%--<div id="divOpenLocallinkers" style="display: none;">
            <a href="locallinkers://" onclick="GoToAppStore();">Open Locallinkers</a>
        </div>--%>
        <%--<div>
            <a href="http://www.locallinkers.com"
                data-app="locallinkers"
                data-store-android="com.hbs.hashbrownsys.locallinkers"
                data-store-ios="1098179119">Start Application</a>
        </div>--%>
        <%-- <div id="divDownloadAppLink" style="position:absolute;top:80px;height:100px;background:#ffffff;display:none;">
          <a >Click here to download our app</a>
      </div>
          <div>
            <a href="http://www.locallinkers.com"
                data-app="locallinkers"
                data-store-android="com.hbs.hashbrownsys.locallinkers"
                data-store-ios="1098179119">Start Application</a>
        </div>
        <div>
            <a id="my-link" ">click here</a>
        </div>--%>
        <%-- <a href="#" data-uri="locallinkers://" onclick="clickHandler(this.dataset.uri)">open locallinkers</a>--%>
    </form>
</body>
</html>
