import { Component, OnInit } from '@angular/core';

import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-proprietario',
  templateUrl: './proprietario.component.html',
  styleUrls: ['./proprietario.component.css']
})
export class ProprietarioComponent implements OnInit {

  constructor(private http: HttpClient) { }

  proprietarios: any = [];

  modalTitle = "";

  ProprietarioCpfCnpj = "";
  ProprietarioNome = "";
  ProprietarioEndereco = "";

  ProprietarioCpfCnpjFilter = "";
  ProprietarioNomeFilter = "";
  ProprietarioEnderecoFilter = "";

  proprietariosWithoutFilter: any = [];

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList() {
    this.http.get<any>(environment.apiBaseUri + '/Proprietario')
      .subscribe(data => {
        this.proprietarios = data;
        this.proprietariosWithoutFilter = data;
      });
  }

  addClick() {
    this.modalTitle = "Adicionar proprietario";
    this.ProprietarioCpfCnpj = "";
    this.ProprietarioNome = "";
    this.ProprietarioEndereco = "";
  }

  editClick(proprietario: any) {
    this.modalTitle = "Editar proprietario";
    this.ProprietarioCpfCnpj = proprietario.cpfCnpj;
    this.ProprietarioNome = proprietario.nome;
    this.ProprietarioEndereco = proprietario.endereco;
  }

  createClick() {
    var val = {
      cpfCnpj: this.ProprietarioCpfCnpj,
      nome: this.ProprietarioNome,
      endereco: this.ProprietarioEndereco
    };

    this.http.post(environment.apiBaseUri + '/Proprietario', val)
      .subscribe({
        next: () => this.refreshList(),
        error: (err) => console.log('HTTP Error', err)
      });
  }

  updateClick() {
    var val = {
      cpfCnpj: this.ProprietarioCpfCnpj,
      nome: this.ProprietarioNome,
      endereco: this.ProprietarioEndereco
    };

    this.http.put(environment.apiBaseUri + '/Proprietario', val)
      .subscribe({
        next: () => this.refreshList(),
        error: (err) => console.log('HTTP Error', err)
      });
  }

  deleteClick(cpfCnpj: any) {
    if (confirm('Você tem certeza?')) {
      this.http.delete(environment.apiBaseUri + '/Proprietario/' + cpfCnpj)
        .subscribe({
          next: () => this.refreshList(),
          error: (err) => console.log('HTTP Error', err)
        });
    }
  }

  filtrarCpfCnpj() {
    var ProprietarioCpfCnpjFilter = this.ProprietarioCpfCnpjFilter;

    this.proprietarios = this.proprietariosWithoutFilter.filter(
      function (el: any) {
        return el.cpfCnpj.toString().toLowerCase().includes(
          ProprietarioCpfCnpjFilter.toString().trim().toLowerCase())
      }
    );
  }

  filtrarNome() {
    var ProprietarioNomeFilter = this.ProprietarioNomeFilter;

    this.proprietarios = this.proprietariosWithoutFilter.filter(
      function (el: any) {
        return el.nome.toString().toLowerCase().includes(
          ProprietarioNomeFilter.toString().trim().toLowerCase())
      }
    );
  }

  filtrarEndereco() {
    var ProprietarioEnderecoFilter = this.ProprietarioEnderecoFilter;

    this.proprietarios = this.proprietariosWithoutFilter.filter(
      function (el: any) {
        return el.endereco.toString().toLowerCase().includes(
          ProprietarioEnderecoFilter.toString().trim().toLowerCase())
      }
    );
  }
}