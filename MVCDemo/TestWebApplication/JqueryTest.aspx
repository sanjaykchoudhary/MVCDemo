<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JqueryTest.aspx.cs" Inherits="TestWebApplication.JqueryTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Jquery Beginner</title>
    <script src="scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            //for all modern browsers.
            if (document.addEventListener)
            {
                document.getElementById("button1").addEventListener('click', clickHandler, false);
            }
            else
            {
                //for IE <9.
                document.getElementById('button1').attachEvent('onclick', clickHandlerOld);
            }
        }
        function clickHandler()
        {
            alert('Jquery Test');
        }

        function clickHandlerOld() {
            alert('Jquery Test old');
        }
        $(document).ready(function () {
            $('#button1').click(function () {
                alert('Jquery Test');
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="button" value="Click Me" id="button1" />
    </div>
    </form>
</body>
</html>
