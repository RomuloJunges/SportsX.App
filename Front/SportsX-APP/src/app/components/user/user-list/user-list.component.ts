import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Classification } from 'src/app/models/Classification.enum';
import { User } from 'src/app/models/User';
import { UserService } from 'src/app/services/User.service';


@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  public users!: User[];
  public userToDelete!: User;
  public usersFiltro!: User[];
  public classification = Classification;
  private filtroLista = '';
  modalRef!: BsModalRef;

  constructor(
    private userService: UserService,
    public router: Router,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private modalService: BsModalService
  ) { }

  ngOnInit() {
    this.loadUsers();
  }

  public loadUsers(): void {
    this.spinner.show();
    this.userService.getAllUser().subscribe(
      (response: any) => {
        this.users = response;
        this.usersFiltro = response;
        this.spinner.hide();
      },
      (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os users');
      }
    );
  }

  public get filtroListaUser(): string {
    return this.filtroLista;
  }

  public set filtroListaUser(value: string) {
    this.filtroLista = value;
    this.usersFiltro = this.filtroListaUser ? this.filtrarUsers(this.filtroListaUser) : this.users;
  }

  public filtrarUsers(paramFiltro: string): User[] {
    paramFiltro = paramFiltro.toLocaleLowerCase();
    return this.users.filter(
      user => user.fullName.toLocaleLowerCase().indexOf(paramFiltro) !== -1 ||
        user.companyName.toLocaleLowerCase().indexOf(paramFiltro) !== -1 ||
        user.document.indexOf(paramFiltro) !== -1
    );
  }

  openModal(event: any, template: TemplateRef<any>, user: User): void {
    event.stopPropagation();
    this.userToDelete = user;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef.hide();
    this.spinner.show();

    this.userService.deleteUser(this.userToDelete.id).subscribe(
      (response: any) => {
        if (response.message === 'Deletado') {
          this.spinner.hide();
          this.toastr.success(`O usuário ${this.userToDelete.fullName} foi deletado com sucesso`);
          this.loadUsers();
        }
      },
      (error: any) => {
        this.spinner.hide();
        this.toastr.error(`Ocorreu um erro ao tentar deletar o usuário ${this.userToDelete.fullName}`);
      },
    );
  }

  decline(): void {
    this.modalRef.hide();
  }
}
