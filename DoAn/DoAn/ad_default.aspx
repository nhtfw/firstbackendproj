<%@ Page Title="" Language="C#" MasterPageFile="~/ad_layout.Master" AutoEventWireup="true" CodeBehind="ad_default.aspx.cs" Inherits="DoAn.ad_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .wrapper {
            margin-top: 80px;
            background: white;
            padding: 30px 50px 50px 50px;
            width: 1150px;
        }

        .sort-section {
            display: flex;
            align-items: center;
            background-color: #eceaea;
        }

            .sort-section * {
                margin-left: 20px;
            }

        .sort-select * {
            padding: 10px;
            background-color: white;
            color: black;
        }

        input[type="radio"]:checked + label {
            background-color: #ee4d2d; /* Đặt màu nền thành màu cam */
            color: white;
        }

        input[type="radio"] {
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            border-radius: 0;
            width: 16px;
            height: 16px;
            border: 1px solid #ccc;
            padding: 10px;
            display: none;
        }

            input[type="radio"]:checked {
                background-color: #007bff;
            }

        .search-section {
            margin-left: 270px;
            display: flex;
            justify-content: center;
            align-items: center;
        }

            .search-section .tb-search {
                height: 25px;
            }

            .search-section .btn-search {
                width: 20px;
                height: 20px;
                margin-left: 5px;
            }

        .btn-add-device {
            text-align: center;
            text-decoration: none;
            font-weight: bold;
        }

            .btn-add-device:hover {
                color: cornflowerblue;
            }


        #ContentPlaceHolder1_GridView1 {
            width: 1150px;
            border-collapse: collapse;
            table-layout: fixed;
        }

            #ContentPlaceHolder1_GridView1 td {
                border: 1px solid #000; /* Đặt border cho header */
                padding: 8px; /* Tạo khoảng cách giữa nội dung và border */
                width: 50px;
                overflow: hidden;
                text-overflow: ellipsis;
                height: 80px;
            }

            #ContentPlaceHolder1_GridView1 .img-device {
                width: 80px;
            }

        .btn-container {
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
        }

        .btn {
            width: 120px;
            height: 40px;
        }

            .btn:hover {
                cursor: pointer;
            }

        .btn-edit {
            margin-bottom: 5px;
            border: 1px solid rgba(0, 0, 0, .09);
            color: white;
            background-color: #ee4d2d;
            border: 0;
            width: 120px;
        }

        .btn-delete {
            background-color: white;
            border: 1px solid rgba(0, 0, 0, .09);
        }

            .btn-delete:hover {
                border: 1px solid black;
                text-decoration: underline;
            }
    </style>
    <div class="wrapper">
        <a href="admin_adddevice.aspx" class="btn-add-device">
            <img src="image/add.png" style="width: 15px" />
            Thêm sản phẩm</a>
        <div class="sort-section">
            <p>Sắp xếp theo: </p>
            <asp:RadioButtonList ID="rbtSort" runat="server" CssClass="sort-select" RepeatLayout="Flow" RepeatDirection="Horizontal"
                AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem Text="Tên sản phẩm" Value="TENSANPHAM"></asp:ListItem>
                <asp:ListItem Text="Đơn giá thấp" Value="DONGIA ASC"></asp:ListItem>
                <asp:ListItem Text="Đơn giá cao" Value="DONGIA DESC"></asp:ListItem>
                <asp:ListItem Text="Danh mục" Value="MADANHMUC"></asp:ListItem>
            </asp:RadioButtonList>
            <div class="search-section">
                <asp:TextBox ID="tbSearch" runat="server" CssClass="tb-search" Placeholder="Tìm kiếm"></asp:TextBox>
                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/image/search.png" CssClass="btn-search"
                    OnClick="btnSearch_Click" />
            </div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MASANPHAM" HeaderText="Mã sản phẩm" />
                <asp:TemplateField HeaderText="Hình">
                    <ItemTemplate>
                        <asp:Image ID="lbDeviceImg" runat="server" ImageUrl='<%# "image/" + Eval("HINH") %>' CssClass="img-device"></asp:Image></td>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TENSANPHAM" HeaderText="Tên sản phẩm" />
                <asp:BoundField DataField="MOTA" HeaderText="Mô tả" />
                <asp:BoundField DataField="DONGIA" HeaderText="Đơn giá" />
                <asp:BoundField DataField="MADANHMUC" HeaderText="Danh mục" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <div class="btn-container">
                            <asp:Button ID="btnEdit" runat="server" CommandArgument='<%# Eval("MASANPHAM") %>' CssClass="btn-edit btn" Text="Chỉnh sửa" OnClick="btnEdit_Click" />
                            <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("MASANPHAM") %>' CssClass="btn-delete btn" Text="Xóa" OnClick="btnDelete_Click" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
