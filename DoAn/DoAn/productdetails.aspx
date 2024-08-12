<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="productdetails.aspx.cs" Inherits="DoAn.productdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .main-content {
            margin-top: 150px;
            display: flex;
            align-content: center;
            justify-content: center;
        }

        .product-details {
            display: flex;
            align-content: center;
            justify-content: center;
            background: white;
            width: 1200px;
            padding-right: 30px;
            padding-bottom: 30px;
            border-radius: 10px;
        }

        .device-image {
            width: 400px;
            margin: 20px;
        }

        .product-table td {
            font-weight: bold;
        }

        .device-name {
            font-size: 30px;
        }

        .price {
            color: #d0011b;
            font-size: 20px;
        }

        .btn {
            color: white;
            font-size: medium;
            background-color: #ee4d2d;
            border: 0;
            width: 170px;
            padding: 10px;
        }

        .btn:hover {
            cursor:pointer;
        }

        .second-content, .third-content {
            display: flex;
            align-content: center;
            justify-content: center;
            margin-top: 20px;
        }

        .describe-device {
            padding: 20px;
            background-color: white;
            width: 1200px;
            border-radius: 10px;
        }

        .others-device {
            padding: 20px;
            width: 1200px;
            border-radius: 10px;
        }

        .other-device {
            flex-direction: column;
            background-color: white;
            padding: 10px;
            height: 320px;
            border-radius: 5px;
            display: flex;
            align-content: center;
            justify-content: center;
            flex-direction: column;
            margin-left: 29px;
            height: 250px;
            background-color: white
        }

        .other-device *{
            display: flex;
            align-content: center;
            justify-content: center;
        }

        .other-device .device-img {
            width: 170px;
        }

        .other-device .device-name {
            text-decoration: none;
            color: black;
            margin-top: 8px;

            font-size: 15px;
        }

             .other-device .device-name:hover, .device-img:hover {
                color: #4343f6;
            }

        .other-device .device-price {
            color: rgb(211, 1, 1);
            font-size: 15px;

            margin-top: 8px;
        }
    </style>
    <div class="main-content">
        <div class="product-details">
            <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound">
                <ItemTemplate>
                    <table class="product-table">
                        <tr>
                            <td rowspan="6">
                                <asp:Image ID="imgDevice" runat="server" CssClass="device-image" ImageUrl='<%# "image/" + Eval("HINH") %>' /></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 70px;">
                                <asp:Label ID="lbDeviceName" runat="server" CssClass="device-name" Text='<%# Eval("TENSANPHAM") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 70px;">
                                <asp:Label ID="lbPrice" runat="server" CssClass="price" Text='<%# Eval("DONGIA") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Vận chuyển: </td>
                            <td>
                                <asp:TextBox ID="tbTrans" runat="server" CssClass="transport-info" AutoPostBack="true" OnTextChanged="tbTrans_TextChanged"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Số điện thoại: </td>
                            <td>
                                <asp:TextBox ID="tbPhoneNumber" runat="server" CssClass="phone-number-info" AutoPostBack="true" OnTextChanged="tbPhoneNumber_TextChanged"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Số lượng: </td>
                            <td>
                                <asp:TextBox ID="tbCount" runat="server" Text="1" TextMode="Number" CssClass="count" AutoPostBack="true" OnTextChanged="tbCount_TextChanged"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn-add btn" Text="Thêm vào giỏ hàng" OnClick="btnAdd_Click" /></td>
                            <td>
                                <asp:Button ID="btnBuy" runat="server" CssClass="btn-buy btn" Text="Mua ngay" OnClick="btnBuy_Click" /></td>
                        </tr>
                    </table>
                    <asp:Label ID="lbThongBao" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="second-content">
        <div class="describe-device">
            <h3>Mô tả</h3>
            <asp:DataList ID="DataList2" runat="server">
                <ItemTemplate>
                    <asp:Label ID="lbMota" runat="server" Text='<%# Eval("MOTA") %>' CssClass="lb-mota"></asp:Label>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="third-content">
        <div class="others-device">
            <h3>Có lẽ bạn sẽ thích</h3>
            <asp:DataList ID="DataList3" runat="server" RepeatColumns="5">
                <ItemTemplate>
                    <section class="other-device">
                        <asp:ImageButton ID="btnDeviceImage" runat="server" ImageUrl='<%# "image/" + Eval("HINH") %>' CssClass="device-img img-trans" CommandArgument='<%# Eval("MASANPHAM") %>' OnClick="btnDeviceImage_Click" />
                        <asp:LinkButton ID="lbDeviceTitle" runat="server" Text='<%# Eval("TENSANPHAM") %>' CssClass="device-name" CommandArgument='<%# Eval("MASANPHAM") %>' OnClick="lbDeviceTitle_Click"></asp:LinkButton>
                        <asp:Label ID="lbPrice" runat="server" Text='<%# Eval("DONGIA") %>' CssClass="device-price"></asp:Label>
                    </section>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>

</asp:Content>
