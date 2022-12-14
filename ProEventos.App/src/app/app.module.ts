import { NgModule, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";

import { AppRoutingModule } from '@app/app-routing.module';
import { AppComponent } from '@app/app.component';
import { EventoService } from '@app/services/evento.service';
import { EventosComponent } from '@app/components/eventos/eventos.component';
import { PalestrantesComponent } from '@app/components/palestrantes/palestrantes.component';
import { DateTimeFormatPipe } from '@app/helpers/dateTimeFormat.pipe';
import { ContatosComponent } from '@app/components/contatos/contatos.component';
import { DashboardComponent } from '@app/components/dashboard/dashboard.component';
import { PerfilComponent } from '@app/components/users/perfil/perfil.component';
import { NavbarComponent } from '@app/shared/navbar/navbar.component';
import { TitulosComponent } from '@app/shared/titulos/titulos.component';
import { ListarComponent } from '@app/components/eventos/listar/listar.component';
import { DetalhesComponent } from '@app/components/eventos/detalhes/detalhes.component';
import { AdicionarComponent } from '@app/components/eventos/adicionar/adicionar.component';
import { EditarComponent } from '@app/components/eventos/editar/editar.component';
import { UsersComponent } from '@app/components/users/users.component';
import { LoginComponent } from '@app/components/users/login/login.component';
import { RegistrationComponent } from '@app/components/users/registration/registration.component';

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
    ReactiveFormsModule,
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

  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [EventoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
