<%@ Page Title="" Language="C#" MasterPageFile="~/ad_layout.Master" AutoEventWireup="true" CodeBehind="admin_adddevice.aspx.cs" Inherits="DoAn.admin_adddevice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .wrapper {
            margin-top: 100px;
        }

        .add-form {
            background-color: white;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            padding: 30px;
            --mainColor: #F96F3A;
            --slaveColor: #F96F3A;
            --highlightColor: #FDE677;
            color: #333;
            margin: 0;
            border-radius: 12px;
            box-shadow: 0 0 16px rgba(0,0,0,.11);
            background-color: #fff;
            padding: 50px 50px;
        }

        .input {
            width: 500px;
            margin-top: 10px;
            height: 30px;
        }

        .file-upload-container {
            margin-top: 10px;
            margin-right: 180px;
        }

        .ddl-brand {
            width: 394px;
            height: 30px
        }

        .ddl-brand-container {
            display: flex;
            align-items: center;
        }

            .ddl-brand-container p {
                margin-right: 20px;
                display: block;
            }

        .lb-thongbao{
            margin-top: 20px;
            color:red;
        }

        .btn-container{
            margin-top: 40px;
        }

        .btnadd {
            font-size: medium;
            width: 120px;
            padding: 10px;
            border: 1px solid rgba(0, 0, 0, .09);
            margin-left: 260px;
            color: white;
            font-size: medium;
            background-color: #ee4d2d;
            border: 0;
            width: 120px;
            padding: 10px;
            margin-bottom: 7px;
        }

            .btnadd:hover {
                cursor: pointer;
            }

        .btnback {
            font-size: medium;
            width: 120px;
            padding: 10px;
            border: 1px solid rgba(0, 0, 0, .09);

            color: black;
            background-color: white;
            font-size: 13px;
        }

        .btnback:hover {
            cursor: pointer;
            text-decoration: underline;
            border: 1px solid black;
        }
    </style>
    <div class="wrapper">
        <div class="add-form">
            <h3>Thêm sản phẩm</h3>
            <asp:TextBox ID="tbMasanpham" runat="server" placeholder="Mã sản phẩm(*)" CssClass="input"></asp:TextBox>
            <asp:TextBox ID="tbTensanpham" runat="server" placeholder="Tên sản phẩm(*)" CssClass="input"></asp:TextBox>
            <asp:TextBox ID="tbMota" runat="server" TextMode="MultiLine" placeholder="Mô tả" CssClass="input"></asp:TextBox>
            <div class="file-upload-container">
                Hình ảnh:
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
            <asp:TextBox ID="tbDongia" runat="server" TextMode="Number" placeholder="Đơn giá(*)" CssClass="input"></asp:TextBox>
            <div class="ddl-brand-container">
                <p>Danh mục(*): </p>
                <asp:DropDownList ID="ddlBrand" runat="server" CssClass="input ddl-brand">
                    <asp:ListItem Text="Xiaomi" Value="xiaomi" />
                    <asp:ListItem Text="Samsung" Value="samsung" />
                    <asp:ListItem Text="iPhone" Value="iphone" />
                    <asp:ListItem Text="Realme" Value="realme" />
                    <asp:ListItem Text="Vivo" Value="vivo" />
                    <asp:ListItem Text="Oppo" Value="oppo" />
                </asp:DropDownList>
            </div>
            <asp:Label ID="lbThongBao" runat="server" CssClass="lb-thongbao"></asp:Label>
            <div class="btn-container">
                <asp:Button ID="btnBack" runat="server" Text="Hủy" CssClass="btnback btn" OnClick="btnBack_Click" />
                <asp:Button ID="btnadd" runat="server" Text="Thêm" CssClass="btnadd btn" OnClick="btnadd_Click" />
            </div>
            
        </div>
    </div>

</asp:Content>
