<%@ Page Title="Relatorio pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RelatorioPedidos.aspx.cs" Inherits="Trabalho1POO2.WebForm.Paginas.RelatorioPedidos" %>
<%@ Register Src="~/Componentes/ResumoPedido.ascx" TagPrefix="ex" TagName="ResumoPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <hr/>
    <div class="row">
        <div class="col-lg-4">
            <div class="form-group">
                <label for="txtNumeroPedido">Numero Pedido:</label>
                <asp:TextBox CssClass="form-control" runat="server" ID="txtNumeroPedido" TextMode="Number" />
            </div>
        </div>
        <div class="col-lg-4" style="display:flex; justify-items:center">
            <div class="form-group">
                <label for="btnPesquisar">Pesquisar:</label><br />
                <asp:Button  CssClass="btn btn-default" runat="server" ID="btnPesquisar" OnClick="btnPesquisar_Click" Text="Pesquisar" />
            </div>
        </div>
    </div>
    <ex:ResumoPedido  runat="server" ID="cpnResumoPedido" Visible="false"></ex:ResumoPedido>    
</asp:Content>
