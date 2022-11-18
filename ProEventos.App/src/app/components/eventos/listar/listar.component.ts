import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Evento } from '../../../models/Evento';
import { EventoService } from 'src/app/services/evento.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';

@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrls: ['./listar.component.scss']
})
export class ListarComponent implements OnInit {

  modalRef?: BsModalRef;

  public events: Evento[] = [];
  public eventsFilters: Evento[] = [];

  public showImage: boolean = true;
  private _searchData: string = '';

  public get searchData(): string {
    return this._searchData;
  }

  public set searchData(value : string) {
    this._searchData = value;
    this.eventsFilters = this.searchData ? this.searchEvents(this.searchData) : this.events;
  }

  public searchEvents(indexOf: string ): Evento[] {
    indexOf = indexOf.toLocaleLowerCase();
    return this.events.filter(
      (event: { ds_Tema: string; ds_Cidade: string }) =>
        event.ds_Tema.toLocaleLowerCase().indexOf(indexOf) !== -1 ||
        event.ds_Cidade.toLocaleLowerCase().indexOf(indexOf) !== -1
      )
  }

  constructor(private eventoService: EventoService,
              private modalService: BsModalService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService,
              private router: Router
              ) { }

  ngOnInit() {
    this.spinner.show();
    this.getEvents();
  }

  public getEvents(): void{
    this.eventoService.getEvent() .subscribe({
        next: (eventos: Evento[]) =>  {
        this.events = eventos;
        this.eventsFilters = this.events;
      },
      error: (error: any)  => {
        this.spinner.hide()
        this.toastr.error('Erro ao carregar eventos!', 'Error!');
      },
      complete: () => this.spinner.hide()
    });
  }

  showImages(): void{
    this.showImage = !this.showImage;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Evento excluido com sucesso!', 'Excluido!');
    this.router.navigate([`eventos`]);
  }

  decline(): void {
    this.modalRef?.hide();
  }

  eventoById(id: number): void{
    this.router.navigate([`eventos/detalhes/${id}`]);
  }

}
