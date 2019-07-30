<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StepBulkEntry.ascx.cs" Inherits="RockWeb.Blocks.Steps.StepBulkEntry" %>

<asp:UpdatePanel ID="pnlGatewayListUpdatePanel" runat="server">
    <ContentTemplate>

        <asp:HiddenField ID="hfStepId" runat="server" />

        <asp:Panel ID="pnlDetails" CssClass="panel panel-block" runat="server">

            <div class="panel-heading">
                <h1 class="panel-title">
                    <i class="fa fa-truck"></i>
                    Step Bulk Entry
                </h1>
            </div>

            BULK ENTRY

        </asp:Panel>

    </ContentTemplate>
</asp:UpdatePanel>
