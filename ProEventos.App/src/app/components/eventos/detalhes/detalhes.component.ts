import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
  styleUrls: ['./detalhes.component.scss']
})
export class DetalhesComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }


  eventoById(id: number): void{
    this.router.navigate([`eventos/editar/${id}`]);
  }
}
