import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VeiculoComponent } from './veiculo/veiculo.component';
import { ProprietarioComponent } from './proprietario/proprietario.component';

const routes: Routes = [
  { path: '', redirectTo: '/veiculo', pathMatch: 'full' },
  { path: 'veiculo', component: VeiculoComponent },
  { path: 'proprietario', component: ProprietarioComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
