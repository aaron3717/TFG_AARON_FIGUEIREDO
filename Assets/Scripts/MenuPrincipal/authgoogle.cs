using UnityEngine;
using Firebase;
using Firebase.Auth;

public class AuthTester : MonoBehaviour
{
    private FirebaseAuth auth;

    void Start()
    {
        // Inicializar Firebase Auth
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                auth = FirebaseAuth.DefaultInstance;
                // Llamar a la función de prueba de autenticación
                TestAuthentication();
            }
            else
            {
                Debug.LogError($"Failed to initialize Firebase Auth: {task.Exception}");
            }
        });
    }

    void TestAuthentication()
    {
        if (auth != null)
        {
            // Verificar si hay un usuario actualmente autenticado
            FirebaseUser currentUser = auth.CurrentUser;
            if (currentUser != null)
            {
                // Usuario autenticado, imprimir información de usuario
                Debug.Log($"User authenticated: {currentUser.DisplayName} ({currentUser.Email})");
            }
            else
            {
                // No hay usuario autenticado, intentar iniciar sesión con Google
                SignInWithGoogle();
            }
        }
        else
        {
            Debug.LogError("Firebase Auth is not initialized!");
        }
    }

    void SignInWithGoogle()
    {
        // Configurar el proveedor de autenticación con Google
        GoogleSignIn();
    }

    void GoogleSignIn()
    {
        // Obtener las credenciales de Google
        Credential credential = GoogleAuthProvider.GetCredential(null, null);

        // Iniciar sesión con las credenciales obtenidas
        auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithCredentialAsync was canceled.");
            }
            else if (task.IsFaulted)
            {
                Debug.LogError($"SignInWithCredentialAsync encountered an error: {task.Exception}");
            }
            else
            {
                // Acceso exitoso, el usuario está autenticado
                FirebaseUser user = task.Result;
                Debug.Log($"User signed in successfully: {user.DisplayName} ({user.Email})");
            }
        });
    }
}
