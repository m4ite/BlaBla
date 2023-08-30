import { Component } from '@angular/core';
import { CargoService } from '../Services/CargoService/cargo.service';
import { Cargo } from '../Services/CargoService/Cargo';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-create-cargo-page',
  templateUrl: './create-cargo-page.component.html',
  styleUrls: ['./create-cargo-page.component.css']
})
export class CreateCargoPageComponent {

  constructor(private cargoService: CargoService, private router: Router, private route: ActivatedRoute) { }

  subscription: any;
  communityName = ""
  dataCargo: Cargo[] = [];

  selecionado : Cargo = 
  {
    nome : "",
    editMembers : false,
    addPost : false,
    createCargo : false,
    editCommunity : false,
    deleteCommunity : false
  }

  title = ""
  editMembers = false
  addPost = false
  createCargo = false
  editCommunity = false
  deleteCommunity = false

  addPostUpdate = false
  editMembersUpdate = false
  createCargoUpdate = false
  editCommunityupdate = false
  deleteCommunityUpdate = false

  ngOnInit(): void {
    this.subscription = this.route.params.subscribe(params => {
      this.communityName = params['communityName'];
    });

    

    this.cargoService.GetCargo(this.communityName)
      .subscribe(res => {
        res.forEach(cargo => {
          this.dataCargo.push(cargo)
        })
      })
  }


  create() {
    let cargo: Cargo =
    {
      nome: this.title,
      editMembers: this.editMembers,
      addPost: this.addPost,
      createCargo: this.createCargo,
      editCommunity: this.editCommunity,
      deleteCommunity: this.deleteCommunity
    }

    console.log(cargo)

    this.cargoService.Add(cargo, this.communityName)
      .subscribe(res => {
        this.router.navigate(["/manageCommunity/" + this.communityName]);
      });
  }

  updateCargo() {

    let cargo: Cargo =
    {
      nome: this.selecionado.nome,
      editMembers: this.selecionado.editMembers,
      addPost: this.selecionado.addPost,
      createCargo: this.selecionado.createCargo,
      editCommunity: this.selecionado.editCommunity,
      deleteCommunity: this.selecionado.deleteCommunity
    }

    this.cargoService.Update(cargo, this.communityName)
      .subscribe(res =>{
        this.router.navigate(['/manageCommunity/' + this.communityName])
      })
  }

  filter(name:string)
  {
    this.dataCargo.forEach(cargo => {
      if(cargo.nome == name)
      {
        this.selecionado = cargo
        this.addPostUpdate = cargo.addPost
        this.editMembersUpdate = cargo.editMembers
        this.createCargoUpdate = cargo.createCargo
        this.editCommunityupdate = cargo.editCommunity
        this.deleteCommunityUpdate = cargo.deleteCommunity
      }
        
    });
  }
}
