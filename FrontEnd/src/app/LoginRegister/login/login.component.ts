import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormControlOptions, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { ToastrService } from 'ngx-toastr';
import { AdminloginService } from 'src/app/service/adminlogin.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public fb:FormBuilder,private service:AdminloginService,public router:Router,public toastr:ToastrService,public toast:NgToastService) { }
  loginForm:FormGroup;
  formValid:boolean;
  ngOnInit(): void {
    this.loginUser();
  }
  loginUser()
  {
    this.loginForm = this.fb.group({
      emailAddress:[null,Validators.compose([Validators.required,Validators.email])],
      password:[null,Validators.compose([Validators.required])]
    });
  }
  get emailAddress(){
    return this.loginForm.get('emailAddress') as FormControl;
  }
  get password(){
    return this.loginForm.get('password') as FormControl;
  }
  OnSubmit(){
      this.formValid = true;
      if(this.loginForm.valid)
      {
        this.service.loginUser([
          this.loginForm.value.emailAddress,
          this.loginForm.value.password
        ]).subscribe((res:any)=>{

          if(res.result == 1)
          {
            if(res.data.message == "Login Successfully")
            {
              this.service.setToken(res.data.data);
              let tokenpayload = this.service.decodedToken();
              this.service.setCurrentUser(tokenpayload);
              console.log(tokenpayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]);
              this.toast.success({detail:"SUCCESS",summary:res.data.message,duration:3000});
              if(tokenpayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] === 'admin')
              {
                this.router.navigate(['admin/dashboard']);
              }
              else if(tokenpayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] === 'user')
              {
                this.router.navigate(['/home']);
              }

            }
            else
            {
              // this.toastr.error(res.data.message);
              this.toast.error({detail:"ERROR",summary:res.data.message,duration:3000});
            }
          }
          else
          {
            // this.toastr.error(res.message);
            this.toast.error({detail:"ERROR",summary:res.message,duration:3000});
          }
        });
        this.formValid = false;
      }
  }
}
