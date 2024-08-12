<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="searched.aspx.cs" Inherits="DoAn.searched" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .wrapper {
            display: flex;
            justify-content: center;
            align-items:center;
        }

        .searched-section {
            margin-top: 150px;
            width: 900px;
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
            margin-bottom: 15px;
            height: 250px;
            background-color: white
        }

            .other-device * {
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
    <div class="wrapper">
        <div class="searched-section">
            <h3 class="search-notification">Kết quả tìm kiếm cho: '<asp:Label ID="lbSearched" runat="server"></asp:Label>'</h3>
            <asp:DataList ID="DataList3" runat="server" RepeatColumns="4">
                <ItemTemplate>
                    <section class="other-device">
                        <asp:ImageButton ID="btnDeviceImage" runat="server" ImageUrl='<%# "image/" + Eval("HINH") %>' CssClass="device-img img-trans" CommandArgument='<%# Eval("MASANPHAM") %>' OnCommand="btnDeviceImage_Command" />
                        <asp:LinkButton ID="lbDeviceTitle" runat="server" Text='<%# Eval("TENSANPHAM") %>' CssClass="device-name" CommandArgument='<%# Eval("MASANPHAM") %>' OnClick="lbDeviceTitle_Click" ></asp:LinkButton>
                        <asp:Label ID="lbPrice" runat="server" Text='<%# Eval("DONGIA") %>' CssClass="device-price"></asp:Label>
                    </section>
                </ItemTemplate>
            </asp:DataList>
            <asp:label ID="lbSearchFail" runat="server"></asp:label>
        </div>
    </div>
</asp:Content>
