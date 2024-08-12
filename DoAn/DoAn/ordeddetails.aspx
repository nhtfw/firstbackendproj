<%@ Page Title="" Language="C#" MasterPageFile="~/NestedUserdetails.master" AutoEventWireup="true" CodeBehind="ordeddetails.aspx.cs" Inherits="DoAn.ordeddetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UserDetails" runat="server">
    <style>
        .getmadh {
            display: none;
        }

        .main-content h3 {
            margin: 0;
            margin-bottom: 10px;
        }

        .main-content {
            background-color: #eceaea;
        }

        .device-img {
            width: 100px;
        }

        .ord {
            width: 1000px;
            background-color: white;
            margin-bottom: 20px;
            padding: 10px;
            border-radius: 10px;
        }

            .ord td {
                width: 250px;
                text-align: center;
            }

        .btn {
            font-size: medium;
            width: 120px;
            padding: 10px;
            border: 1px solid rgba(0, 0, 0, .09);
        }

        .btn-more {
            color: white;
            font-size: medium;
            background-color: #ee4d2d;
            border: 0;
            width: 120px;
            padding: 10px;
            margin-bottom: 7px;
        }

        .btn-cancel {
            color: black;
            background-color: white;
            font-size: 13px;
        }

        .btn:hover {
            cursor: pointer;
        }

        .btn-cancel:hover {
            text-decoration: underline;
        }
    </style>
    <h3>Đơn hàng của tôi</h3>
    <asp:DataList ID="dlOrded" runat="server">
        <ItemTemplate>
            <asp:Label ID="madh" runat="server" Text='<%# Eval("MADONHANG") %>' CssClass="getmadh"></asp:Label>
            <table class="ord">
                <tr>
                    <td></td>
                    <td></td>
                    <td>Số lượng</td>
                    <td>Thành tiền</td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="btnDeviceImage" runat="server" ImageUrl='<%# "image/" + Eval("HINH") %>' CssClass="device-img" CommandArgument='<%# Eval("MASANPHAM") %>' /></td>
                    <td>
                        <asp:LinkButton ID="lbDeviceTitle" runat="server" Text='<%# Eval("TENSANPHAM") %>' CssClass="device-name" CommandArgument='<%# Eval("MASANPHAM") %>'></asp:LinkButton></td>
                    <td>
                        <asp:Label ID="tbCount" runat="server" Text='<%# Eval("SOLUONG") %>' CssClass="count"></asp:Label></td>
                    <td>
                        <asp:Label ID="lbTotalPrice" runat="server" Text='<%# Eval("TONGDONGIA") %>' CssClass="total-price"></asp:Label></td>
                    <td>
                        <asp:Button ID="btnMoreOrdedDetails" runat="server" Text="Chi tiết đơn" CssClass="btn-more btn" OnClick="btnMoreOrdedDetails_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Hủy đơn hàng" CssClass="btn-cancel btn" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
