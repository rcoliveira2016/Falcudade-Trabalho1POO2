﻿<%@ Page Title="Produtos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Trabalho1POO2.WebForm.Paginas.Produtos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <hr/>
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <label for="txtNome">Descrição:</label>
                <asp:TextBox CssClass="form-control" runat="server" ID="txtDescricao" />
            </div>
        </div>
        <div class="col-lg-6">
            <div class="form-group">
                <label for="txtNome">Preço:</label>
                <asp:TextBox CssClass="form-control" runat="server" ID="txtPreco" TextMode="Number" />
            </div>
        </div>
    </div>
    <asp:Button  CssClass="btn btn-success" runat="server" ID="btnSalvar" OnClick="btnSalvar_Click" Text="Salvar" />
    <asp:GridView ID="grdDados" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
            <asp:BoundField DataField="PrecoVenda" HeaderText="Preço Venda" />

        </Columns>
    </asp:GridView>
</asp:Content>
