import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  public usersFiltro!: User[];
  public classification = Classification;
  private filtroLista = '';

  constructor(
    private userService: UserService,
    public router: Router,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
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

  public get filtroListaUser(): string{
    return this.filtroLista;
  }

  public set filtroListaUser(value: string){
    this.filtroLista = value;
    this.usersFiltro = this.filtroListaUser ? this.filtrarUsers(this.filtroListaUser) : this.users;
  }

  public filtrarUsers(paramFiltro: string): User[]{
    paramFiltro = paramFiltro.toLocaleLowerCase();
    return this.users.filter(
      user => user.fullName.toLocaleLowerCase().indexOf(paramFiltro) !== -1 ||
      user.companyName.toLocaleLowerCase().indexOf(paramFiltro) !== -1 ||
      user.document.indexOf(paramFiltro) !== -1
    );
  }
}
