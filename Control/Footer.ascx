<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="Footer" %>

<div class="row">
    <div class="col12">
        <asp:LinkButton ID="lnkPrivacyPolicy" runat="server" Text="Privacy Policy"
            meta:resourcekey="lnkPrivacyPolicyResource1"></asp:LinkButton>

        <asp:LinkButton ID="lnkTerms" runat="server" Text="Terms of Service"
            meta:resourcekey="lnkTermsResource1"></asp:LinkButton>

        

    </div>
</div>
<div class="row">
    <div class="col12">
        <asp:Label ID="lblProgName" runat="server" Text="CM Secure "
            meta:resourcekey="lblProgNameResource1" />
        © 2009-
                     <asp:Label ID="lblcurrentYear" runat="server"
                         meta:resourcekey="lblcurrentYearResource1" />

        <asp:Label ID="lblComName" runat="server" Text="Almaalim Company"
            meta:resourcekey="lblComNameResource1" />


    </div>

</div>


<!--/Footer-->
</tr>
</table> 