<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FaceRegister.aspx.cs" Inherits="CloudStorage.FaceRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
       <script src="Webcam.js" type="text/javascript"></script>
       <script type="text/javascript">

           $(function () { /* Setting img size, img type, quality */
               Webcam.set({
                   width: 720,
                   height: 420,
                   image_format: 'jpg',
                   jpg_quality: 90
               });
               Webcam.attach('#idwebcam');

               $("#btncapture").click(function () { /* Starting to Show Stream on Webpage being captures from Webcam */
                   Webcam.snap(function (data_url) {
                       $("#idcaptured")[0].src = data_url;
                   });
               })
           });

       </script>
    <script type="text/javascript">
        function getBase64Image(img) { /* Generating Base64 String from Image  */
            var canvas = document.createElement("canvas");
            canvas.width = img.width;
            canvas.height = img.height;
            var ctx = canvas.getContext("2d");
            ctx.drawImage(img, 0, 0);

            var dataURL = canvas.toDataURL("image/png");
            return dataURL.replace(/^data:image\/(png|jpg);base64,/, "");
        }

        function abcd() {
            var base64 = getBase64Image(document.getElementById("idcaptured"));
            /* console.log(base64); (For debugging) */
            document.getElementById("hidden_img").value = base64; /* Saving Base64 String in hidden field */
            document.getElementById('<%=hiddenbtn.ClientID%>').click(); 
            /* Clicking Hidden button to activate function hiddenbtn_Click in C# */
        }
    </script>

</head>
<body style="background-color:#dde5f4; font-family: Arial, Helvetica, sans-serif;">
    <form id="form1" runat="server">
            <asp:HiddenField ID="hidden_img" runat="server" />
        <asp:Button ID="hiddenbtn" runat="server" Text="Button" OnClick="hiddenbtn_Click"  style="display:none;"/>
         <table border="0" cellpadding="0" cellspacing="0">
  
             <!--   Properly Placing Elements  -->
        <tr>
            <th align="center">Live Cam</th>
            <th align="center" style="padding-left:100px">Pic Captured</th>
        </tr>
            <tr>
                <td>
        <div id="idwebcam" >
        </div>
                    </td>
                <td style="padding-left:100px">
        <img id="idcaptured"  />
                    </td>
                </tr>
            <tr>
                <td align="center" style="text-align:center;">
        <input  type="button" id="btncapture" value="Capture"  />
                    </td>
                <td align="center" style=" text-align:center;  padding-left:100px">
                    <input type="button" id="abcdbutton" value="Register" onclick="abcd()" style="align-content:center;" />
                </td>
                </tr>
            </table>
    </form>
    </body>
</html>
