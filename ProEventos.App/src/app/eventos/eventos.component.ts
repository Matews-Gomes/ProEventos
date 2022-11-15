import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public events: any = [];
  public eventsFilters: any = [];

  public showImage: boolean = true;
  private _searchData: string = '';

  public get searchData(): string {
    return this._searchData;
  }

  public set searchData(value : string) {
    this._searchData = value;
    this.eventsFilters = this.searchData ? this.searchEvents(this.searchData) : this.events;
  }

  searchEvents(indexOf: string ): any {
    indexOf = indexOf.toLocaleLowerCase();
    return this.events.filter(
      (event: { ds_Tema: string; ds_Cidade: string }) =>
        event.ds_Tema.toLocaleLowerCase().indexOf(indexOf) !== -1 ||
        event.ds_Cidade.toLocaleLowerCase().indexOf(indexOf) !== -1
      )
  }

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEvents();
  }

  public getEvents(): void{
    this.http.get('https://localhost:7210/api/eventos').subscribe(
      response => {
        this.events = response;
        this.eventsFilters = this.events;
      },
      error => console.error(error),
    );
  }

  showImages(){
    this.showImage = !this.showImage;
  }


}
