<%@ Page Title="" Language="C#" MasterPageFile="~/NestedUserdetails.master" AutoEventWireup="true" CodeBehind="userdetails.aspx.cs" Inherits="DoAn.userdetails2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UserDetails" runat="server">
    <style>
        .profile-wrapper{
            display:flex;
            justify-content:center;
            align-items:center;
        }

        .user-table {
            width: 500px;
            height: 400px;
            margin-left: 0px;
            margin-right: 0px;
        }

            .user-table td {
                width: 100px;
            }

        .update-section {
            display: flex;
            align-content: center;
            justify-content: center;
            align-items: center;
            height: 70px;
        }

        .img-change{
            width:230px;
        }

        .user-img{
            width:230px;
        }

        .btn-update {
            color: white;
            font-size: medium;
            background-color: #ee4d2d;
            border: 0;
            width: 170px;
            padding: 10px;
        }

            .btn-update:hover {
                cursor: pointer;
            }
    </style>
    <h3>Hồ sơ của tôi</h3>
    <asp:DataList ID="dlUserInformation" runat="server">
        <ItemTemplate>
            <asp:Label ID="lbID" runat="server" Text='<%# Eval("MANGUOIDUNG") %>' Visible="false"></asp:Label>
            <div class="profile-wrapper">
                <table class="user-table">
                    <tr>
                        <td>Tên đăng nhập: 
                        </td>
                        <td>
                            <asp:Label ID="lbloginname" runat="server" Text='<%# Eval("TENDANGNHAP") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Tên người dùng: 
                        </td>
                        <td>
                            <asp:TextBox ID="lbusername" runat="server" Text='<%# Eval("TENNGUOIDUNG") %>' CssClass="text-box" AutoPostBack="true" OnTextChanged="lbusername_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Số điện thoại: 
                        </td>
                        <td>
                            <asp:TextBox ID="lbphonenumber" runat="server" Text='<%# Eval("SODIENTHOAI") %>' CssClass="text-box" AutoPostBack="true" OnTextChanged="lbphonenumber_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Địa chỉ: 
                        </td>
                        <td>
                            <asp:TextBox ID="lblocation" runat="server" Text='<%# Eval("DIACHI") %>' CssClass="text-box" AutoPostBack="true" OnTextChanged="lblocation_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Nhập mật khẩu trước khi cập nhật:</td>
                        <td>
                            <asp:TextBox ID="tbPass" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="img-change">
                    <asp:Image ID="imgUser" runat="server" ImageUrl='<%# "image/" + Eval("HINH") %>' CssClass="user-img"></asp:Image>
                    <asp:FileUpload ID="FileUpload1" runat="server"/>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
    <div class="update-section">
        <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CssClass="btn-update" OnClick="btnUpdate_Click" />
    </div>
    <asp:Label ID="lbThongbao" runat="server"></asp:Label>
</asp:Content>
