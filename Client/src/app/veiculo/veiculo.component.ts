import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-veiculo',
  templateUrl: './veiculo.component.html',
  styleUrls: ['./veiculo.component.css']
})
export class VeiculoComponent implements OnInit {

  constructor(private http: HttpClient) { }

  veiculos: any = [];

  modalTitle = "";

  VeiculoMarca = "";
  VeiculoPlaca = "";
  VeiculoProprietario = "";

  VeiculoPlacaFilter = "";
  VeiculoMarcaFilter = "";
  VeiculoProprietarioFilter = "";

  veiculosWithoutFilter: any = [];

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList() {
    this.http.get<any>(environment.apiBaseUri + '/Veiculo')
      .subscribe(data => {
        this.veiculos = data;
        this.veiculosWithoutFilter = data;
      });
  }

  addClick() {
    this.modalTitle = "Adicionar Veiculo";
    this.VeiculoPlaca = "";
    this.VeiculoMarca = "";
    this.VeiculoProprietario = "";
  }

  editClick(dep: any) {
    this.modalTitle = "Editar Veiculo";
    this.VeiculoPlaca = dep.placa;
    this.VeiculoMarca = dep.marca;
    this.VeiculoProprietario = dep.cpfCnpj;
  }

  createClick() {
    var val = {
      marca: this.VeiculoMarca,
      placa: this.VeiculoPlaca,
      cpfCnpj: this.VeiculoProprietario
    };

    this.http.post(environment.apiBaseUri + '/Veiculo', val)
      .subscribe({
        next: () => this.refreshList(),
        error: (err) => console.log('HTTP Error', err)
      });
  }

  updateClick() {
    var val = {
      marca: this.VeiculoMarca,
      placa: this.VeiculoPlaca,
      cpfCnpj: this.VeiculoProprietario
    };

    this.http.put(environment.apiBaseUri + '/Veiculo', val)
      .subscribe({
        next: () => this.refreshList(),
        error: (err) => console.log('HTTP Error', err)
      });
  }

  deleteClick(placa: any) {
    if (confirm('Você tem certeza?')) {
      this.http.delete(environment.apiBaseUri + '/Veiculo/' + placa)
        .subscribe({
          next: () => this.refreshList(),
          error: (err) => console.log('HTTP Error', err)
        });
    }
  }

  filtrarPlaca() {
    var VeiculoPlacaFilter = this.VeiculoPlacaFilter;

    this.veiculos = this.veiculosWithoutFilter.filter(
      function (el: any) {
        return el.placa.toString().toLowerCase().includes(
          VeiculoPlacaFilter.toString().trim().toLowerCase())
      }
    );
  }

  filtrarMarca() {
    var VeiculoMarcaFilter = this.VeiculoMarcaFilter;

    this.veiculos = this.veiculosWithoutFilter.filter(
      function (el: any) {
        return el.marca.toString().toLowerCase().includes(
          VeiculoMarcaFilter.toString().trim().toLowerCase())
      }
    );
  }

  filtrarProprietario() {
    var VeiculoProprietarioFilter = this.VeiculoProprietarioFilter;

    this.veiculos = this.veiculosWithoutFilter.filter(
      function (el: any) {
        return el.cpfCnpj.toString().toLowerCase().includes(
          VeiculoProprietarioFilter.toString().trim().toLowerCase())
      }
    );
  }
}
