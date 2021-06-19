import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Phone } from 'src/app/models/Phone';
import { User } from 'src/app/models/User';
import { PhoneService } from 'src/app/services/Phone.service';
import { UserService } from 'src/app/services/User.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.scss'],
})
export class UserDetailsComponent implements OnInit {
  form!: FormGroup;
  user!: User;
  phoneId!: number;
  method = 'post';
  classificationSelected = 1;

  constructor(
    public fb: FormBuilder,
    public router: Router,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private activatedRouter: ActivatedRoute,
    private userService: UserService,
    private phoneService: PhoneService
  ) {}

  ngOnInit() {
    this.loadUser();
    this.validation();
  }

  public loadUser() {
    var userId = Number(this.activatedRouter.snapshot.paramMap.get('id'));
    if (userId != null && userId != 0) {
      this.spinner.show();

      this.method = 'put';
      this.userService.getUserById(userId).subscribe(
        (user: User) => {
          this.user = { ...user };
          this.classificationSelected = this.user.classification;
          this.form.patchValue(this.user);

          this.user.phones.forEach((phone) => {
            this.phones.push(this.createPhone(phone));
          });

          this.spinner.hide();
        },
        () => {
          this.toastr.error('Erro ao tentar carregar o usuário');
        }
      );
    }
  }

  get f(): any {
    return this.form.controls;
  }

  get phones(): FormArray {
    return this.form.get('phones') as FormArray;
  }

  get methodPut(): boolean {
    return this.method === 'put';
  }

  private validation(): void {
    this.form = this.fb.group({
      fullName: ['', [Validators.required, Validators.maxLength(100)]],
      companyName: ['', Validators.maxLength(100)],
      document: ['', [Validators.minLength(11), Validators.maxLength(14)]],
      email: ['', [Validators.required, Validators.email]],
      cep: ['', [Validators.minLength(8), Validators.maxLength(8)]],
      classification: ['', Validators.required],
      phones: this.fb.array([]),
    });
  }

  public saveUser(): void {
    this.spinner.show();
    if (this.form.valid) {
      this.user =
        this.method === 'post'
          ? { ...this.form.value }
          : {
              id: this.user.id,
              ...this.form.value,
            };

      if (this.method === 'post') {
        this.userService.post(this.user).subscribe(
          (userResponse: User) => {
            this.spinner.hide();
            this.toastr.success('Usuário salvo com sucesso');
            this.router.navigate([`user/details/${userResponse.id}`]);
          },
          (error: any) => {
            console.log(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar usuário');
          }
        );
      } else if (this.method === 'put') {
        this.userService.put(this.user).subscribe(
          (userResponse: User) => {
            this.spinner.hide();
            this.toastr.success('Usuário salvo com sucesso');
            this.router.navigate([`user/details/${userResponse.id}`]);
          },
          (error: any) => {
            console.log(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar usuário');
          }
        );
      }
    }
  }

  public savePhones(): void {
    this.spinner.show();
    if (this.form.controls.phones.valid) {
      this.phoneService
        .savePhone(this.user.id, this.form.value.phones)
        .subscribe(
          () => {
            this.spinner.hide();
            this.toastr.success('Telefones salvos com sucesso');
          },
          (error: any) => {
            this.spinner.hide();
            console.log(error);
            this.toastr.error('Erro ao tentar salvar telefones');
          }
        );
    }
  }

  public addPhone(): void {
    this.phones.push(this.createPhone({ id: 0 } as Phone));
  }

  public createPhone(phone: Phone): FormGroup {
    return this.fb.group({
      id: [phone.id],
      number: [
        phone.number,
        [Validators.minLength(10), Validators.maxLength(11)],
      ],
    });
  }

  public removePhone(index: number): void {
    this.phoneId = this.phones.get(index + '.id')?.value;

    if (this.user != null) {
      this.phoneService.deletePhone(this.user.id, this.phoneId).subscribe(
        () => {
          this.toastr.success('Telefone deletado');
        },
        (error: any) => {
          console.log(error);
        }
      );
    }
    this.phones.removeAt(index);
  }

  public resetForm(): void {
    this.form.reset();
  }

  public checkDocument(): void {
    const value = this.form.controls['document'].value;

    if (value === '') {
      this.form.controls['document'].setErrors(null);
    }
  }
}
