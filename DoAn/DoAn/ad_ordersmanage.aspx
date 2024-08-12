<%@ Page Title="" Language="C#" MasterPageFile="~/ad_layout.Master" AutoEventWireup="true" CodeBehind="ad_ordersmanage.aspx.cs" Inherits="DoAn.ad_ordersmanage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <div class="sort-section">
            <p>Sắp xếp theo: </p>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MADONHANG" HeaderText="Mã đơn hàng" />
                <asp:TemplateField HeaderText="Hình">
                    <ItemTemplate>
                        <asp:Image ID="lbDeviceImg" runat="server" ImageUrl='<%# "image/" + Eval("HINH") %>' CssClass="img-device"></asp:Image>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MANGUOIDUNG" HeaderText="Mã người dùng" />
                <asp:BoundField DataField="SOLUONG" HeaderText="Số lượng" />
                <asp:TemplateField HeaderText="Địa chỉ">
                    <ItemTemplate>
                        <asp:Label ID="lbPhoneNumber" runat="server" Text='<%# Eval("SODIENTHOAI") %>'></asp:Label>
                        <asp:Label ID="lbDirect" runat="server" Text='<%# Eval("DIACHI") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="lbNote" HeaderText="Ghi chú" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
