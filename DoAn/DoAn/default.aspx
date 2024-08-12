<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DoAn.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .main-content, .devices-list, .device {
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
        }

        .ads-section {
            margin-top: 150px;
            width: 1100px;
            background-color: rgb(249, 180, 52);
            border-radius: 10px;
        }

            .ads-section .device {
                flex-direction: column;
                background-color: white;
                padding: 10px;
                height: 320px;
                margin: 10px;
                border-radius: 5px;
            }

            .ads-section .device-img {
                width: 170px;
            }

            .ads-section .device-name {
                text-decoration: none;
                font-weight: bold;
                color: black;
                padding: 10px;
            }

                .ads-section .device-name:hover, .device-img:hover {
                    color: #4343f6;
                }

            .ads-section .device-price {
                color: rgb(211, 1, 1);
            }

        .ads-section-2 {
            background-color: orange;
            margin-top: 50px;
        }

        .ads-2-banner {
            width: 1100px;
        }

        
    </style>
    <div class="main-content">
        <div class="ads-section-1 ads-section">
            <h1 class="ads-title" style="margin-left: 10px">Tuần lễ Samsung</h1>
            <div class="devices-list">
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" CssClass="Datalist1">
                    <ItemTemplate>
                        <section class="device">
                            <asp:ImageButton ID="btnDeviceImage" runat="server" ImageUrl='<%# "image/" + Eval("HINH") %>' CssClass="device-img img-trans" CommandArgument='<%# Eval("MASANPHAM") %>' OnCommand="btnDeviceImage_Command" />
                            <asp:LinkButton ID="lbDeviceTitle" runat="server" Text='<%# Eval("TENSANPHAM") %>' CssClass="device-name" CommandArgument='<%# Eval("MASANPHAM") %>' OnClick="lbDeviceTitle_Click"></asp:LinkButton>
                            <asp:Label ID="lbPrice" runat="server" Text='<%# Eval("DONGIA") %>' CssClass="device-price"></asp:Label>
                        </section>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>

        <div class="ads-section-2 ads-section">
            <div>
                <img class="ads-2-banner" src="image/ads-2.png" />
            </div>
            <div class="devices-list">
                <asp:DataList ID="DataList2" runat="server" RepeatColumns="5" CssClass="Datalist1">
                    <ItemTemplate>
                        <section class="device">
                            <asp:ImageButton ID="btnDeviceImage" runat="server" ImageUrl='<%# "image/" + Eval("HINH") %>' CssClass="device-img img-trans" CommandArgument='<%# Eval("MASANPHAM") %>' OnCommand="btnDeviceImage_Command" />
                            <asp:LinkButton ID="lbDeviceTitle" runat="server" Text='<%# Eval("TENSANPHAM") %>' CssClass="device-name" CommandArgument='<%# Eval("MASANPHAM") %>' OnClick="lbDeviceTitle_Click"></asp:LinkButton>
                            <asp:Label ID="lbPrice" runat="server" Text='<%# Eval("DONGIA") %>' CssClass="device-price"></asp:Label>
                        </section>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>

