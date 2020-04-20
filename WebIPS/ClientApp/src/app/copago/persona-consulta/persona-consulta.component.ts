import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { CopagoService } from '../../services/copago.service';

@Component({
  selector: 'app-persona-consulta',
  templateUrl: './persona-consulta.component.html',
  styleUrls: ['./persona-consulta.component.css']
})
export class PersonaConsultaComponent implements OnInit {

  personas: Persona[];
  constructor(private copagoService: CopagoService) { }

  ngOnInit(): void {
    this.copagoService.get().subscribe(result => {

      this.personas = result;

    });
  }

}
