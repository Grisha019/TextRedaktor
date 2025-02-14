using redaktor2.Model;
using redaktor2.View;
using System;
using System.IO; // Необходимо для работы с файлами
using System.Windows.Forms;

namespace redaktor2.Controller
{
    public class TextController
    {
        private readonly TextModel _model;
        private readonly TextView _view;

        public TextController(TextModel model, TextView view)
        {
            _model = model;
            _view = view;

            _view.OpenFile += OnOpenFile;
            _view.SaveFile += OnSaveFile;
            _view.ClearText += OnClearText;
        }

        private void OnOpenFile()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Читаем текст из файла и устанавливаем его в модель и представление
                    _model.Text = File.ReadAllText(openFileDialog.FileName);
                    _view.SetText(_model.Text);
                }
            }
        }

        private void OnSaveFile()
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Записываем текст из представления в файл
                    File.WriteAllText(saveFileDialog.FileName, _view.GetText());
                }
            }
        }

        private void OnClearText()
        {
            // Очищаем текст в модели и представлении
            _model.Text = string.Empty;
            _view.SetText(_model.Text);
        }
    }
}
