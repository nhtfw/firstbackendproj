<%@ Page Title="" Language="C#" MasterPageFile="~/login_and_logout.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="DoAn.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .register-section {
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
            font-family: ROBOTO LIGHT;
            margin: 0;
            border-radius: 12px;
            box-shadow: 0 0 16px rgba(0,0,0,.11);
            background-color: #fff;
            padding: 85px 99px;
        }

            .register-section .input {
                width: 500px;
                margin-top: 10px;
            }

        .input {
            height: 30px;
        }

        .btnDangKi {
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
    <div class="register-section section">
        <h3>ĐĂNG KÝ</h3>
        <asp:TextBox ID="tbNewUserNameLogin" runat="server" Placeholder="Tên đăng nhập (dài hơn 8 kí tự)" CssClass="input"></asp:TextBox>
        <asp:TextBox ID="tbNewUserName" runat="server" Placeholder="Họ và tên" CssClass="input"></asp:TextBox>
        <asp:TextBox ID="tbNewPassword" runat="server" TextMode="Password" Placeholder="Mật khẩu (dài hơn 6 kí tự)" CssClass="input"></asp:TextBox>
        <div class="file-upload-container">
            Hình ảnh:
                <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        <asp:TextBox ID="tbNewPhonenumber" runat="server" Placeholder="Số điện thoại" CssClass="input"></asp:TextBox>
        <asp:TextBox ID="tbNewLocation" runat="server" Placeholder="Địa chỉ" CssClass="input"></asp:TextBox>
        <asp:Button ID="btnDangKi" runat="server" Text="Đăng ký" CssClass="btnDangKi" OnClick="btnDangKi_Click" />
        <asp:Label ID="lbThongBao" runat="server"></asp:Label>
        <div>
            Đã có tài khoản? <a href="login.aspx">Đăng nhập</a>
        </div>
    </div>
</asp:Content>
