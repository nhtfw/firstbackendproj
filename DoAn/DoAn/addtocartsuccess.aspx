<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="addtocartsuccess.aspx.cs" Inherits="DoAn.addtocartsuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        .wrapper {
            display: flex;
            justify-content: center;
            height: 700px;
        }

        .alert {
            margin-top:250px; 
            padding: 50px;
            background-color: white;
            display: flex;
            justify-content:center;
            align-items:center;
            flex-direction:column;
            width: 600px;
            height: 400px;
            border-radius: 20px;
        }

        .btn-home {
            font-size: medium;
            width: 120px;
            padding: 10px;
            border: 1px solid rgba(0, 0, 0, .09);
            color: white;
            font-size: medium;
            background-color: #ee4d2d;
            border: 0;
            width: 200px;
            padding: 10px;
            margin-bottom: 7px;
        }

            .btn-home:hover {
                cursor: pointer;
            }
    </style>
    <div class="wrapper">
        <div class="alert">
            <h2 class="alert-title">Thêm vào giỏ thành công</h2>
            <asp:Button ID="btnHome" runat="server" Text="Trở về trang chủ" CssClass="btn-home" OnClick="btnHome_Click" />
        </div>
    </div>
</asp:Content>
