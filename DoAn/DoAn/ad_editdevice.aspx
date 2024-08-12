<%@ Page Title="" Language="C#" MasterPageFile="~/ad_layout.Master" AutoEventWireup="true" CodeBehind="ad_editdevice.aspx.cs" Inherits="DoAn.ad_editdevice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .wrapper {
            margin-top: 100px;
        }

        .img-device {
            width: 300px;
        }

        .form-container {
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

        .add-form {
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .input-form {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
        }

        .input {
            width: 500px;
            margin-top: 10px;
            height: 30px;
        }

        .file-upload{
            width: 430px;
        }

        .ddl-brand{
            width: 410px;
            height: 30px
        }

        .btnupdate {
            font-size: medium;
            width: 120px;
            padding: 10px;
            border: 1px solid rgba(0, 0, 0, .09);
            
        }

        .btnupdate {
            color: white;
            font-size: medium;
            background-color: #ee4d2d;
            border: 0;
            width: 120px;
            padding: 10px;
            margin-bottom: 7px;
        }

            .btnupdate:hover {
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

            margin-right: 480px;
        }

        .btnback:hover {
            cursor: pointer;
            text-decoration: underline;
            border: 1px solid black;
        }

        .lb-thongbao{
            color:red;
        }
    </style>
    <div class="wrapper">
        <asp:DataList ID="DataList1" runat="server">
            <ItemTemplate>
                <div class="form-container">
                    <div class="add-form">
                        <div class="img-device">
                            <asp:Image ID="tbHinh" runat="server" ImageUrl='<%# "image/" + Eval("HINH") %>' CssClass="img-device"></asp:Image>
                        </div>
                        <div class="input-form">
                            <asp:Label ID="tbMasanpham" runat="server" CssClass="input" Text='<%# Eval("MASANPHAM") %>'></asp:Label>
                            <asp:TextBox ID="tbTensanpham" runat="server" placeholder="Tên sản phẩm(*)" CssClass="input" Text='<%# Eval("TENSANPHAM") %>'></asp:TextBox>
                            <asp:TextBox ID="tbMota" runat="server" TextMode="MultiLine" placeholder="Mô tả" CssClass="input" Text='<%# Eval("MOTA") %>'></asp:TextBox>
                            <div>
                                Hình ảnh:
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="input file-upload" />
                            </div>
                            <asp:TextBox ID="tbDongia" runat="server" TextMode="Number" placeholder="Đơn giá(*)" CssClass="input" Text='<%# Eval("DONGIA") %>'></asp:TextBox>
                            <div>
                                Danh mục(*): 
                <asp:DropDownList ID="ddlBrand" runat="server" CssClass="input ddl-brand" SelectedValue='<%# Eval("MADANHMUC") %>'>
                    <asp:ListItem Text="Xiaomi" Value="xiaomi" />
                    <asp:ListItem Text="Samsung" Value="samsung" />
                    <asp:ListItem Text="iPhone" Value="iphone" />
                    <asp:ListItem Text="Realme" Value="realme" />
                    <asp:ListItem Text="Vivo" Value="vivo" />
                    <asp:ListItem Text="Oppo" Value="oppo" />
                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <asp:Label ID="lbThongBao" runat="server" CssClass="lb-thongbao"></asp:Label>
                    <div>
                        <asp:Button ID="btnBack" runat="server" Text="Hủy" CssClass="btnback" OnClick="btnBack_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CssClass="btnupdate" OnClick="btnUpdate_Click" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
