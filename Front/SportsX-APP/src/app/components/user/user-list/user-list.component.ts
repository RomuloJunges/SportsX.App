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
  public classification = Classification;

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
        this.spinner.hide();
      },
      (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os users');
      }
    );
  }
}
