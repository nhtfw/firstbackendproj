<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="moreordeddetails.aspx.cs" Inherits="DoAn.moreordeddetails" %>

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

        .ord {
            width: 100%;
            height: 300px;
        }

            .ord td {
                width: 100px;
                text-align: center; /* Căn giữa theo chiều ngang */
                vertical-align: middle; /* Căn giữa theo chiều dọc */
            }

            .ord tr {
                height: 40px;
            }

        .img-ord {
            width: 100px;
        }

        .note-section {
            margin-left: 20px;
            margin-bottom: 30px;
        }

        .tb-note {
            resize: none;
            width: 800px;
            height: 100px;
            
        }

        .btn {
            font-size: medium;
            width: 200px;
            padding: 10px;
            border: 1px solid rgba(0, 0, 0, .09);
            color: black;
            background-color: white;
            font-size: 13px;
            margin-left: 650px;
        }

        .btn-cancel:hover {
            text-decoration: underline;
            cursor: pointer;
            border: 1px solid black;
        }
    </style>

    <div class="wrapper">
        <div class="main-content">
            <a href="ordeddetails.aspx" class="btn-return"><img src="image/return.png"/>Trở về</a>
            <asp:DataList ID="DataList1" runat="server">
                <ItemTemplate>
                    <h3 style="margin-left:19.5px;">Đơn hàng <asp:Label ID="lbOrdedID" runat="server" Text='<%# Eval("MADONHANG") %>'></asp:Label></h3>
                    <div class="trans-section">
                        <h4>Địa chỉ nhận hàng</h4>
                        <asp:Label ID="lbDirect" runat="server" CssClass="lb-direct" Text='<%# Eval("DIACHI") %>'></asp:Label>
                        <br />
                        <asp:Label ID="lbPhonenumber" runat="server" CssClass="lb-phone-number" Text='<%# Eval("SODIENTHOAI") %>'></asp:Label>
                    </div>
                    <div class="ord-section">
                        <h4>Chi tiết đơn hàng</h4>
                        <table class="ord">
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
                                    <asp:Label ID="lbOrdCount" runat="server" Text='<%# Eval("SOLUONG") %>' CssClass="lb-ord-count"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lbOrdTotalPrice" runat="server" Text='<%# Eval("TONGDONGIA") %>' CssClass="lb-ord-total-price"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="note-section">
                        <h4>Ghi chú</h4>
                        <asp:Label ID="tbNote" runat="server" Text='<%# Eval("GHICHU") %>' CssClass="tb-note"></asp:Label>
                    </div>
                    <div class="confirm-section">
                        <asp:Button ID="btnCancel" runat="server" Text="Hủy đơn hàng" CssClass="btn-cancel btn" OnClick="btnCancel_Click" />
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
