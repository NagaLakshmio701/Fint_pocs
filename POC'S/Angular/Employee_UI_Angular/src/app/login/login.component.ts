import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  loginobj:any={
    email:'',
    password:'',
  }

  router=inject(Router)

  onlogin(){
    if(this.loginobj.email=='snl@gmail.com' && this.loginobj.password=="12345"){
      this.router.navigateByUrl('/client')
      localStorage.setItem('empUser',this.loginobj.email)
      console.log("user",localStorage.getItem('empUser'))
    }else{
      alert("wrong Credentials")
    }
  }

}
