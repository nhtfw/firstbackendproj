<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="DoAn.payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .wrapper {
            display: flex;
            align-content: center;
            justify-content: center;
            align-items: center;
        }

        .main-content {
            margin-top: 150px;
            padding: 20px;
            width: 900px;
            background-color: white;
            display: flex;
            justify-content: center;
            flex-direction: column;
            border-radius: 10px;
        }

        .main-content .btn-return{
            text-decoration: none;
            color: black;
            font-size:medium;
            margin-left: 16px;
        }

        .main-content .btn-return:hover{
            cursor:pointer;
            color: cornflowerblue;
        }

        .main-content .btn-return img{
            width:13px;
            margin-right:2px;
        }

        .trans-section {
            margin-left: 20px;
        }

        .ord-section {
            display: flex;
            justify-content: center;
            flex-direction: column;
            margin-left: 20px;
        }

        .ord-table {
            width: 100%;
            height: 300px;
        }

            .ord-table td {
                width: 100px;
                text-align: center; /* Căn giữa theo chiều ngang */
                vertical-align: middle; /* Căn giữa theo chiều dọc */
            }

            .ord-table tr {
                height: 40px;
            }

        .img-ord {
            width: 100px;
        }

        .note-section{
            margin-left: 20px;
        }

        .tb-note {
            resize: none;
            width: 800px;
            height: 100px; 
            margin-bottom: 15px;
        }

        .btn {
            color: white;
            font-size: medium;
            background-color: #ee4d2d;
            border: 0;
            width: 170px;
            padding: 10px;
            margin-left: 650px;
        }

            .btn:hover {
                cursor: pointer;
            }
    </style>
    <div class="wrapper">
        <div class="main-content">
            <a href="cart.aspx" class="btn-return"><img src="image/return.png"/>Trở về</a>
            <div class="trans-section">
                <h3>Địa chỉ nhận hàng</h3>
                <asp:Label ID="lbDirect" runat="server" CssClass="lb-direct"></asp:Label>
                <br />
                <asp:Label ID="lbPhonenumber" runat="server" CssClass="lb-phone-number"></asp:Label>
            </div>
            <div class="ord-section">
                <h3>Chi tiết đơn hàng</h3>
                <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound">
                    <ItemTemplate>
                        <table class="ord-table">
                            <tr>
                                <td colspan="2">Sản phẩm</td>
                                <td>Đơn giá</td>
                                <td>Số lượng</td>
                                <td>Thành tiền</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image ID="imgOrd" runat="server" ImageUrl='<%# "image/" + Eval("HINH") %>' CssClass="img-ord" /></td>
                                <td>
                                    <asp:Label ID="lbOrdName" runat="server" Text='<%# Eval("TENSANPHAM") %>' CssClass="lb-ord-name" /></td>
                                <td>
                                    <asp:Label ID="lbOrdPrice" runat="server" Text='<%# Eval("DONGIA") %>' CssClass="lb-ord-price"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lbOrdCount" runat="server" CssClass="lb-ord-count"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lbOrdTotalPrice" runat="server" CssClass="lb-ord-total-price"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="note-section">
                <h3>Ghi chú</h3>
                <asp:TextBox ID="tbNote" runat="server" TextMode="MultiLine" CssClass="tb-note"></asp:TextBox>
            </div>
            <div class="confirm-section">
                <asp:Button ID="btnBuy" runat="server" Text="Xác nhận mua hàng" CssClass="btn" OnClick="btnBuy_Click" />
            </div>
            <asp:Label ID="lbThongbao" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
