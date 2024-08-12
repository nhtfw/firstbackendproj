<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ad_login.aspx.cs" Inherits="DoAn.ad_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style>
        body {
            display: flex;
            margin: 0;
            padding: 0;
            justify-content: center;
            align-items: center;
            min-width: 100vh;
            background-color: #eceaea;
        }


        .main {
            width: 350px;
            height: 400px;
            background: white;
            overflow: hidden;
            border-radius: 10px;
            box-shadow: 5px 20px 50px;
            margin: 100px;
        }

        .signup {
            position: relative;
            width: 100%;
            height: 100%;
        }

        label {
            color: #fff;
            font-size: 2.3em;
            justify-content: center;
            display: flex;
            margin: 60px;
            font-weight: bold;
            cursor: pointer;
            transition: .5s ease-in-out;
        }

        input {
            width: 60%;
            height: 20px;
            background: #E0E0E0;
            justify-content: center;
            display: flex;
            margin: 20px auto;
            padding: 10px;
            border: none;
            outline: none;
            border-radius: 5px;
        }

        .btn {
            width: 60%;
            height: 40px;
            margin: 10px auto;
            justify-content: center;
            display: block;
            color: #fff;
            background: black;
            font-size: 1em;
            font-weight: bold;
            margin-top: 20px;
            outline: none;
            border: none;
            border-radius: 5px;
            transition: .2s ease-in;
            cursor: pointer;
        }

            .btn:hover {
                background: burlywood;
            }

        .thongbao {
            margin-left: 130px;
        }
    </style>
    <form id="form1" runat="server">
        <div class="main">
            <div class="signup">
                <form>
                    <label for="chk" aria-hidden="true"></label>
                    <asp:TextBox ID="tbAdminName" runat="server" placeholder="Tên đăng nhập"></asp:TextBox>
                    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" placeholder="Mật khẩu"></asp:TextBox>
                    <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" CssClass="btn" OnClick="btnDangNhap_Click"/>
                    <asp:Label ID="lbThongBao" runat="server" CssClass="thongbao"></asp:Label>
                </form>
            </div>
        </div>
    </form>
</body>
</html>
