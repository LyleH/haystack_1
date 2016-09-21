<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testRunCompare.aspx.cs" Inherits="WebBlacks2.testRunCompare" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align: center">
        <asp:Label ID="title" runat="server"></asp:Label></h2>
    <div class="form-inline">
        <div class="form-group">
            <p><a class="btn btn-primary btn-normal" style="font-size: large" href="TestResults.aspx">&laquo; Back</a></p>
        </div>
        <div class="form-group">
            <div class="container">
                <div class="row" style="align-content: center">
                    <asp:Repeater ItemType="System.string" runat="server" ID="repeaterPassed" SelectMethod="testRows">
                        <ItemTemplate>
                            <div class="col-xs-6">
                                <p><%# Item %></p>
                            </div>
                            <div class="col-xs-6">
                                <p><%# Item %></p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
