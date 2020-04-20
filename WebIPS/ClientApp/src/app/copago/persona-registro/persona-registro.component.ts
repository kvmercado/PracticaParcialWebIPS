import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { CopagoService } from '../../services/copago.service';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {

  persona: Persona;
  constructor(private copagoService: CopagoService) { }

  ngOnInit(): void {
    this.persona = new Persona();
  }

  add() {
    this.copagoService.post(this.persona).subscribe(p => {
      if (p != null) {
        alert('Persona creada!');
        this.persona = p;
      }
    });
  }

}
