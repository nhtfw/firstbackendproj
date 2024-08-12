<%@ Page Title="" Language="C#" MasterPageFile="~/NestedUserdetails.master" AutoEventWireup="true" CodeBehind="notify.aspx.cs" Inherits="DoAn.notify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserDetails" runat="server">
    <style>
        .main-content h3 {
            margin: 0;
            margin-bottom: 10px;
        }

        .main-content {
            background-color: #eceaea;
        }

        .img-notify {
            width: 100px;
        }

        .notify-container{
            display:flex;
            align-items:center;
            background-color:white;
            margin-bottom:10px;
            padding:5px;
            border-radius: 7px;
        }

        .notify-content{
            margin-left: 10px;
            width:800px;
        }
        .btn-delete-noti{
            padding: 30px;
        }
    </style>
    <h3>Thông báo</h3>
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <div class="notify-container">
                <asp:Image ID="imgNotify" runat="server" CssClass="img-notify" ImageUrl='<%# "image/" + Eval("HINH") %>'/>
                <article class="notify-content">
                    <h3>
                        <asp:Label ID="lbTitle" runat="server" CssClass="lb-noti-title" Text='<%# Eval("TIEUDE") %>'></asp:Label>
                    </h3>
                    <p>
                        <asp:Label ID="lbContent" runat="server" CssClass="lb-noti-content" Text='<%# Eval("NOIDUNG") %>'></asp:Label>
                    </p>
                    <p style="font-size: 12px">
                        <asp:Label ID="lbTime" runat="server" CssClass="lb-noti-time" Text='<%# Eval("THOIGIAN") %>'></asp:Label>
                    </p>
                </article>
                <asp:ImageButton ID="btnDeleteNoti" runat="server" CssClass="btn-delete-noti" ImageUrl="~/image/delete.png" CommandArgument='<%# Eval("THOIGIAN") %>' OnClick="btnDeleteNoti_Click"/>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
