<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TestResults.aspx.cs" Inherits="TestResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="headingOne">
                <h4 class="panel-title">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#collapseOne" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">Failed Tests
                    </a>
                </h4>
            </div>
            <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                <div class="panel-body">
                    <asp:Repeater ItemType="System.string" runat="server" ID="repeaterPassed" SelectMethod="testsPassed">
                        <ItemTemplate>
                            <div class="form-inline" onclick="Clicked(<%# Item %>)">
                                <div class="form-group">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/RedCross.jpg" BorderStyle="None" Height="15" ImageAlign="Baseline"></asp:Image>
                                </div>
                                <div class="form-group">
                                    <a href="/TestRunCompare.aspx?TestName=<%# Item %>">
                                        <asp:Label Height=" 15" runat="server">
                                    <%# Item %>
                                        </asp:Label>
                                    </a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="headingTwo">
                <h4 class="panel-title">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#collapseTwo" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">Passed Tests
                    </a>
                </h4>
            </div>
            <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                <div class="panel-body">
                    <asp:Repeater ItemType="System.string" runat="server" ID="repeater1" SelectMethod="testsFailed">
                        <ItemTemplate>
                            <div class="form-inline">

                                <div class="form-group">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/GreenTick.jpg" BorderStyle="None" Height="15" ImageAlign="Baseline"></asp:Image>
                                </div>
                                <div class="form-group">
                                    <a href="/TestRunCompare.aspx?TestName=<%# Item %>">
                                        <asp:Label Height=" 15" runat="server">
                                    <%# Item %>
                                        </asp:Label>
                                    </a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


