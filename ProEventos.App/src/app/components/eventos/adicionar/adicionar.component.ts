import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-adicionar',
  templateUrl: './adicionar.component.html',
  styleUrls: ['./adicionar.component.scss']
})
export class AdicionarComponent implements OnInit {

  form!: FormGroup;
  modalRef?: BsModalRef;

  get control(): any {
    return this.form.controls;
  }

  constructor(private modalService: BsModalService,
              private toastr: ToastrService,
              private formBiulder: FormBuilder) { }

  ngOnInit() {
    this.formValidation();
  }

  public formValidation(): void {
    this.form = this.formBiulder.group({
      ds_Tema: ['', [Validators.required,Validators.minLength(5),Validators.maxLength(50)]],
      dt_Evento: ['', Validators.required],
      qtd_Pessoas: ['', [Validators.required,Validators.max(120000)]],
      ds_Imagem: ['', Validators.required],
      id_Palestrante: ['', Validators.required],
      id_RedeSocial: ['', Validators.required],
      ds_UrlRedeSocial: ['', Validators.required],
      ds_Logradouro: ['', [Validators.required,Validators.minLength(5),Validators.maxLength(120)]],
      ds_Numero: ['', Validators.required],
      ds_Complemento: ['', Validators.maxLength(150)],
      ds_Cep: ['', [Validators.required,Validators.max(8)]],
      ds_Bairro: ['', [Validators.required,Validators.minLength(5),Validators.maxLength(50)]],
      id_Cidade: ['', Validators.required],
      id_Estado: ['', Validators.required],
      ds_Lote: ['', Validators.required],
      vl_Valor: ['', Validators.required],
      dt_Inicio: ['', Validators.required],
      dt_Fim: ['', Validators.required],
      qtd_Lote: ['', Validators.required],
      ds_Telefone: ['', Validators.required],
      ds_Celular: ['', Validators.required],
      ds_Email: ['', [Validators.required,Validators.email]],
    });
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Evento excluido com sucesso!', 'Excluido!');
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
