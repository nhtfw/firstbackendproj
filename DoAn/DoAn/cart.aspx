<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="DoAn.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .getmadh {
            display: none;
        }

        .wrapper {
            display: flex;
            align-content: center;
            justify-content: center;
            margin-top: 100px;
        }

        .ord-list {
            display: flex;
            align-content: center;
            justify-content: center;
            flex-direction: column;
            width: 1400px;
            height: auto;
            padding: 50px;
            border-radius: 10px;
        }

        .device-img {
            width: 100px;
        }

        .ord {
            width: 100%;
            background-color: white;
            margin-bottom: 20px;
            padding: 10px;
        }

            .ord td {
                width: 250px;
                text-align: center;
            }

            .ord tr {
                height:30px;
            }

        .btn-buy {
            color: white;
            font-size: medium;
            background-color: #ee4d2d;
            border: 0;
            width: 170px;
            padding: 10px;
        }

            .btn-buy:hover {
                cursor: pointer;
            }
    </style>
    <div class="wrapper">
        <div class="ord-list">
            <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound">
                <ItemTemplate>
                    <asp:Label ID="madh" runat="server" Text='<%# Eval("MADONHANG") %>' CssClass="getmadh"></asp:Label>
                    <table class="ord">
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>Đơn giá</td>
                            <td>Số lượng</td>
                            <td>Số tiền</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/image/delete.png" CssClass="btn-delete" OnClick="btnDelete_Click" /></td>
                            <td>
                                <asp:ImageButton ID="btnDeviceImage" runat="server" ImageUrl='<%# "image/" + Eval("HINH") %>' CssClass="device-img" CommandArgument='<%# Eval("MASANPHAM") %>' /></td>
                            <td>
                                <asp:LinkButton ID="lbDeviceTitle" runat="server" Text='<%# Eval("TENSANPHAM") %>' CssClass="device-name" CommandArgument='<%# Eval("MASANPHAM") %>'></asp:LinkButton></td>
                            <td>
                                <asp:Label ID="lbPrice" runat="server" Text='<%# Eval("DONGIA") %>' CssClass="device-price"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="tbCount" runat="server" Text='<%# Eval("SOLUONG") %>' TextMode="Number" AutoPostBack="true" OnTextChanged="tbCount_TextChanged" CssClass="count"></asp:TextBox></td>
                            <td>
                                <asp:Label ID="lbTotalPrice" runat="server" Text='<%# Eval("TONGDONGIA") %>' CssClass="total-price"></asp:Label></td>
                            <td>
                                <asp:Button ID="btnBuy" runat="server" CommandArgument='<%# Eval("MADONHANG") %>' Text="Thanh toán" CssClass="btn-buy" OnClick="btnBuy_Click"/></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
