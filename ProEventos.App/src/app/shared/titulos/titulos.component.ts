import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-titulos',
  templateUrl: './titulos.component.html',
  styleUrls: ['./titulos.component.scss']
})
export class TitulosComponent implements OnInit {

  @Input() titulo = '';
  @Input() iconClass = 'fa-solid fa-calendar-check';
  @Input() subTitulo = 'Desde 2022';
  @Input() botaoListar = false;

  constructor(private router: Router) { }

  ngOnInit() {
  }

  listar(): void {
    this.router.navigate([`/${this.titulo.toLocaleLowerCase()}/listar`]);
  }

}
