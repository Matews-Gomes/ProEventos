import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventoService } from './services/evento.service';
import { EventosComponent } from './components/eventos/eventos.component';
import { DateTimeFormatPipe } from './helpers/dateTimeFormat.pipe';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/users/perfil/perfil.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { TitulosComponent } from './shared/titulos/titulos.component';
import { ListarComponent } from './components/eventos/listar/listar.component';
import { DetalhesComponent } from './components/eventos/detalhes/detalhes.component';
import { AdicionarComponent } from './components/eventos/adicionar/adicionar.component';
import { EditarComponent } from './components/eventos/editar/editar.component';
import { UsersComponent } from './components/users/users.component';
import { LoginComponent } from './components/users/login/login.component';
import { RegistrationComponent } from './components/users/registration/registration.component';

@NgModule({
  declarations: [
      AppComponent,
      NavbarComponent,
      EventosComponent,
      ListarComponent,
      DetalhesComponent,
      AdicionarComponent,
      EditarComponent,
      ContatosComponent,
      DashboardComponent,
      PalestrantesComponent,
      PerfilComponent,
      TitulosComponent,
      UsersComponent,
      LoginComponent,
      RegistrationComponent,
      DateTimeFormatPipe
    ],

  imports: [
    FormsModule,
    BrowserModule,
    NgxSpinnerModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
  ],
  providers: [EventoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
