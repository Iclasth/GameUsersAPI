import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-form-field',
  imports: [CommonModule],
  templateUrl: './form-field.html',
  styleUrl: './form-field.css',
})
export class FormField {
  @Input() label: string = '';
  @Input() control?: AbstractControl | null;

  get shouldShowErrors(): boolean {
    return !!(this.control?.invalid && (this.control?.dirty || this.control?.touched) )
  }
  

}
