<%@ Page Title="" Language="C#" MasterPageFile="~/ad_layout.Master" AutoEventWireup="true" CodeBehind="ad_usersmanage.aspx.cs" Inherits="DoAn.ad_usersmanage" %>

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
            margin-left: 540px;
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

        #ContentPlaceHolder1_GridView1 {
            border: 1px solid #000; /* Đặt border cho header */
            padding: 8px; /* Tạo khoảng cách giữa nội dung và border */
            width: 1150px;
            overflow: hidden;
            text-overflow: ellipsis;
            height: 80px;
        }
        #ContentPlaceHolder1_GridView1 td{
            height: 60px;
        }

            #ContentPlaceHolder1_GridView1 .img-user {
                width: 80px;
            }

        .btn-block {
            width: 120px;
            height: 40px;
            margin-bottom: 5px;
            border: 1px solid rgba(0, 0, 0, .09);
            color: white;
            background-color: red;
            border: 0;
            width: 120px;

            color:black;
        }

            .btn-block:hover {
                cursor: pointer;
            }

        .center-btn {
            display: flex;
            justify-content: center;
            align-items: center;
        }
    </style>
    <div class="wrapper">
        <div class="sort-section">
            <p>Sắp xếp theo: </p>
            <asp:RadioButtonList ID="rbtSort" runat="server" CssClass="sort-select" RepeatLayout="Flow" RepeatDirection="Horizontal"
                AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem Text="Tên người dùng" Value="TENNGUOIDUNG"></asp:ListItem>
                <asp:ListItem Text="Địa chỉ" Value="DIACHI"></asp:ListItem>
            </asp:RadioButtonList>
            <div class="search-section">
                <asp:TextBox ID="tbSearch" runat="server" CssClass="tb-search" Placeholder="Tìm kiếm"></asp:TextBox>
                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/image/search.png" CssClass="btn-search"
                    OnClick="btnSearch_Click" />
            </div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MANGUOIDUNG" HeaderText="Mã người dùng" />
                <asp:TemplateField HeaderText="Hình">
                    <ItemTemplate>
                        <asp:Image ID="lbUserImg" runat="server" ImageUrl='<%# "image/" + Eval("HINH") %>' CssClass="img-user"></asp:Image></td>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TENNGUOIDUNG" HeaderText="Tên người dùng" />
                <asp:BoundField DataField="SODIENTHOAI" HeaderText="Số điện thoại" />
                <asp:BoundField DataField="DIACHI" HeaderText="Địa chỉ" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="center-btn">
                            <asp:Button ID="btnBlock" runat="server" CssClass="btn-block" Text="Xóa người dùng" CommandArgument='<%# Eval("MANGUOIDUNG") %>' OnClick="btnBlock_Click" /></div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
