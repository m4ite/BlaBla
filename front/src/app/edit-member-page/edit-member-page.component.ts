import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../Services/UserService/User';
import { UserServiceService } from '../Services/UserService/user-service.service';
import { Cargo } from '../Services/CargoService/Cargo';
import { CargoService } from '../Services/CargoService/cargo.service';
import { Member } from '../Services/MemberService/Member';

@Component({
  selector: 'app-edit-member-page',
  templateUrl: './edit-member-page.component.html',
  styleUrls: ['./edit-member-page.component.css']
})
export class EditMemberPageComponent {
  cargo = "";
  communityName = ""
  subscription: any;
  nickName = ""
  user : User  = {
    email: '',
    nickName: '',
    wordPass: '',
    birthdate: new Date(),
    foto: '',
    cargo: 1
  };


  dataCargo: Cargo[] = [];

  constructor(private router: Router, private route: ActivatedRoute, private service: UserServiceService, private cargoService: CargoService) { }
  
  ngOnInit(): void
  {
    const jwt = sessionStorage.getItem("jwt") ?? ""

    this.subscription = this.route.params.subscribe(params => {
      this.nickName = params['nickName'];
      });

      this.subscription = this.route.params.subscribe(params => {
        this.communityName = params['communityName'];
        });

    this.service.getMember(this.nickName)
    .subscribe(res =>
      this.user = res
      )
      console.log(this.user);
      

    this.cargoService.GetCargo(this.communityName)
    .subscribe(res => {
      res.forEach(cargo => {
        console.log(cargo);
        this.dataCargo.push(cargo)
      })
    })
      
      

  }

 
    submit()
    {
      this.service.submit(this.user, this.cargo, this.communityName)
      .subscribe(res =>
        {
          this.router.navigate(['/membersList/' + this.communityName])
        })
    }

    excluir()
    {
      this.router.navigate(["/membersList"])
    }
}
