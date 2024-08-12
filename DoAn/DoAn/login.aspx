<%@ Page Title="" Language="C#" MasterPageFile="~/login_and_logout.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DoAn.login2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        main .login-section {
            background-color: white;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            padding: 30px;
            --mainColor: #F96F3A;
            --slaveColor: #F96F3A;
            --highlightColor: #FDE677;
            font: 14px/18px Helvetica,Arial,"DejaVu Sans","Liberation Sans",Freesans,sans-serif;
            color: #333;
            text-align: center;
            font-family: ROBOTO LIGHT;
            margin: 0;
            border-radius: 12px;
            box-shadow: 0 0 16px rgba(0,0,0,.11);
            background-color: #fff;
            padding: 85px 99px;
        }

        .login-section .input {
            width: 500px;
            margin-top: 10px;
        }

        .input {
            height: 30px;
        }

        .btnDangNhap {
            --mainColor: #F96F3A;
            --slaveColor: #F96F3A;
            --highlightColor: #FDE677;
            padding: 0;
            font: 14px/18px Helvetica,Arial,"DejaVu Sans","Liberation Sans",Freesans,sans-serif;
            outline: none;
            background-color: var(--mainColor);
            box-shadow: unset;
            border-radius: 100px;
            width: 302px;
            height: 50px;
            border: none;
            text-transform: uppercase;
            color: #fff;
            font-size: 17px;
            max-width: 100%;
            display: block;
            font-family: ROBOTO LIGHT;
            cursor: pointer;
            margin-top: 20px;
        }
    </style>
    <div class="login-section section">
        <h3>ĐĂNG NHẬP</h3>
        <asp:TextBox ID="tbTenDangNhap" runat="server" CssClass="input"></asp:TextBox>
        <asp:TextBox ID="tbMatKhau" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
        <asp:Button ID="btnDangNhap" runat="server" Text="Đăng nhập" CssClass="btnDangNhap" OnClick="btnDangNhap_Click" />
        <asp:Label ID="lbThongBao" runat="server"></asp:Label>
        <div>
            Chưa có tài khoản? <a href="register.aspx">Đăng ký</a>
        </div>
    </div>
</asp:Content>
