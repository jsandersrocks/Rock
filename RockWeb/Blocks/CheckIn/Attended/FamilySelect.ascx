﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FamilySelect.ascx.cs" Inherits="RockWeb.Blocks.CheckIn.Attended.FamilySelect" %>

<asp:UpdatePanel ID="upContent" runat="server">
<ContentTemplate>

    <Rock:ModalAlert ID="maWarning" runat="server" />

    <div class="row-fluid checkin-header">
        <div class="span3">
            <asp:LinkButton ID="lbBack" CssClass="btn btn-primary btn-large btn-block btn-checkin-select" runat="server" OnClick="lbBack_Click" Text="Back"/>
        </div>

        <div class="span6">
            <legend>Search Result</legend>
        </div>

        <div class="span3">
            <asp:LinkButton ID="lbNext" CssClass="btn btn-primary btn-large btn-block btn-checkin-select" runat="server" OnClick="lbNext_Click" Text="Next"/>
        </div>
    </div>
                
    <div class="row-fluid checkin-body">

        <div class="span3">
            <div class="checkin-body-container">
                <asp:Repeater ID="rFamily" runat="server" OnItemCommand="rFamily_ItemCommand">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelectFamily" runat="server" CommandArgument='<%# Eval("Group.Id") %>' CssClass="btn btn-primary btn-large btn-block btn-checkin-select" ><%# Eval("Caption") %><span class="checkin-sub-title"><%# Eval("SubCaption") %></span></asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
                
            </div>
        </div>

        <div class="span3">
            <div class="checkin-body-container">
                <asp:Repeater ID="rPerson" runat="server" OnItemCommand="rPerson_ItemCommand">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelectPerson" runat="server" Text='<%# Container.DataItem.ToString() %>' CommandArgument='<%# Eval("Person.Id") %>' CssClass="btn btn-primary btn-large btn-block btn-checkin-select" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <div class="span3"></div>

        <div class="span3">
            <div class="checkin-body-container">
                <asp:LinkButton ID="lbAddFamily" runat="server" CssClass="btn btn-primary btn-large btn-block btn-checkin-select" OnClick="lbAddFamily_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbAddPerson" runat="server" CssClass="btn btn-primary btn-large btn-block btn-checkin-select" OnClick="lbAddPerson_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbAddVisitor" runat="server" CssClass="btn btn-primary btn-large btn-block btn-checkin-select" OnClick="lbAddVisitor_Click"></asp:LinkButton>                
            </div>
        </div>

    </div>   

</ContentTemplate>
</asp:UpdatePanel>
