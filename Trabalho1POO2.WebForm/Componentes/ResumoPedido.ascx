<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResumoPedido.ascx.cs" Inherits="Trabalho1POO2.WebForm.Componentes.ResumoPedido" %>
<fieldset runat="server" id="fldDadosPedido">
        <legend>Dados Resumo do Pedido Numero: <strong runat="server" id="spnNumero" /></legend>
        <div runat="server" id="divPagamento">
            <asp:Button  CssClass="btn btn-success" runat="server" ID="btnConfrimaPagamento" OnClick="btnConfrimaPagamento_Click" Text="Confirmar pagamento" />
            <hr/>
        </div>
        <dl class="dl-horizontal">
            <dt>Valor Total:</dt>
            <dd><span runat="server" id="spnValorTotal" /></dd>
            <dt>Data da Compra:</dt>
            <dd><span runat="server" id="spnDataCompra" /></dd>
            <dt>Previsão Entrega:</dt>
            <dd><span runat="server" id="spnPrevisaoEntrega" /></dd>
            <dt>Nome cliente:</dt>
            <dd><span runat="server" id="spnNomeCliente" /></dd>
            <dt>Endereço para entrada:</dt>
            <dd><span runat="server" id="spnEnderecoEntrada" /></dd>
            <dt>Esta pago?:</dt>
            <dd><span runat="server" id="spnEstaPago" /></dd>
            <dt runat="server" id="dtDataPagamento">Data Pagamento:</dt>
            <dd runat="server" id="ddDataPagamento"><span runat="server" id="spnDataPagamento" /></dd>
            <dt>Forma pagamento:</dt>
            <dd><span runat="server" id="spnFormaPagamento" /></dd>
            <dt>Frete:</dt>
            <dd><span runat="server" id="spnFrete" /></dd>
        </dl>
        <h3>Itens Comprados</h3>
        <asp:GridView ID="grdItensPedidoResumo" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Descricao" HeaderText="Produto" />
                <asp:BoundField DataField="Total" HeaderText="Total" />
            </Columns>
        </asp:GridView>
    </fieldset>