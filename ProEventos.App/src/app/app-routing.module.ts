import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';

import { EventosComponent } from './components/eventos/eventos.component';
import { AdicionarComponent } from './components/eventos/adicionar/adicionar.component';
import { EditarComponent } from './components/eventos/editar/editar.component';
import { ListarComponent } from './components/eventos/listar/listar.component';
import { DetalhesComponent } from './components/eventos/detalhes/detalhes.component';

import { LoginComponent } from './components/users/login/login.component';
import { UsersComponent } from './components/users/users.component';
import { PerfilComponent } from './components/users/perfil/perfil.component';
import { RegistrationComponent } from './components/users/registration/registration.component';

import { ContatosComponent } from './components/contatos/contatos.component';

const routes: Routes = [
  { path: 'usuarios', redirectTo: 'usuarios/login'},
  {
    path: 'usuarios', component: UsersComponent,
    children: [
      {path: 'registrar-se', component: RegistrationComponent},
      {path: 'login', component: LoginComponent}
    ]
  },
  { path: 'eventos', redirectTo: 'eventos/listar'},
  {
    path: 'eventos', component: EventosComponent,
    children:[
      {path: 'listar', component: ListarComponent},
      {path: 'detalhes/:id', component: DetalhesComponent},
      {path: 'editar/:id', component: EditarComponent},
      {path: 'adicionar', component: AdicionarComponent}
    ]
  },
  {path: 'palestrantes', component: PalestrantesComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'perfil', component: PerfilComponent},
  {path: 'contatos', component: ContatosComponent},
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {path: '**', redirectTo: 'dashboard', pathMatch: 'full'}
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
