<%@ Page Title="Clientes" Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Trabalho1POO2.WebForm.Paginas.Clientes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <hr/>
    <div>
        <div class="form-group">
            <label for="txtNome">Nome</label>
            <asp:TextBox CssClass="form-control" runat="server" ID="txtNome" />
        </div>
        <div class="form-group">
            <label for="txtCPF">CPF</label>
            <asp:TextBox CssClass="form-control" runat="server" ID="txtCPF" />
        </div>
        <div class="form-group">
            <label for="txtCep">Cep</label>
            <asp:TextBox CssClass="form-control" runat="server" ID="txtCep" />
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="txtComplemento">Complemento</label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtComplemento" />
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="txtEndereco">Endereço</label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtEndereco" />
                </div>
            </div>
        </div>
        <div class="row">            
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="txtCidade">Cidade</label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtCidade" />
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="txtEstado">Estado</label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtEstado" />
                </div>
            </div>
        </div>
        <asp:Button runat="server" Text="Cadastrar" ID="btnCadastrarCliente" OnClick="btnCadastrarCliente_Click" />
    </div>
    <hr/>
    <h3>Listagem Clieste Cadastrados</h3>
    <asp:GridView ID="grdDados" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="CPF" HeaderText="CPF" />
            <asp:BoundField DataField="Cep" HeaderText="Cep" />
            <asp:BoundField DataField="EnderecoCompleto" HeaderText="Endereço Completo" />

        </Columns>
    </asp:GridView>
</asp:Content>
