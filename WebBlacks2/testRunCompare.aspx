<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testRunCompare.aspx.cs" Inherits="WebBlacks2.testRunCompare" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align: center">
        <asp:Label ID="title" runat="server"></asp:Label></h2>
    <div class="form-inline">
        <div class="form-group">
            <p><a class="btn btn-primary btn-normal" style="font-size: large" href="TestResults.aspx">&laquo; Back</a></p>
        </div>
        <div class="form-group">
            <div class ="container">
                <div class="row" style="align-content: center">
                            <div class="col-xs-1">
                                <p>Line Number</p>
                            </div>
                            <div class="col-xs-5">
                                <h3>Last Passing</h3>
                            </div>
                            <div class="col-xs-1">
                                <p>Line Number</p>
                            </div>
                            <div class="col-xs-5">
                                <h3>First Failing</h3>
                            </div>
                        </div>
            </div>
        </div>
        <div class="form-group">
            <div class="container-fluid" style="overflow-y:scroll;max-height:350px">
                <asp:Repeater ItemType="WebBlacks2.Objects.TestCompareLine" runat="server" ID="repeaterPassed" SelectMethod="testRows">
                    <ItemTemplate>
                        <div class="row" style="align-content: center; overflow:auto;background-color:<%# Item.Colour %>">
                           <div class="col-xs-1">
                                <p><%# Item.LineNumber %>.</p>
                            </div>
                            <div class="col-xs-5">
                                <p runat="server"> <%# Item.Before %></p>
                            </div>
                            <div class="col-xs-1">
                                <p><%# Item.LineNumber %>.</p>
                            </div>
                            <div class="col-xs-5">
                                <p runat="server"><%# Item.After %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
